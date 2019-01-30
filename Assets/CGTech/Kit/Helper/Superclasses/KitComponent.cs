using Anglia.CGTech.CKit.Helper.InspectorMessages;
using Anglia.CGTech.CKit.Helper.Library;
using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace Anglia.CGTech.CKit.Helper
{
    [ExecuteInEditMode]
    public abstract class KitComponent : MonoBehaviour
    {
        [HideInInspector]
        //[SerializeField]
        [Ignore]
        public float m_activity = 0;
        private float m_lastActivity = 0;
        /// <summary>
        /// Normalised value indicating how active (1) or passive(0) the component is.
        /// </summary>
        public float Activity
        {
            get
            {
                return m_activity;
            }

            set
            {
                m_activity = value;
            }
        }

        public static float scale;
        const float DEFAULT_OFFSET = 0.1f;
        const float NODE_WIDTH = 1f;

        [HideInInspector]
        public Rect windowDisplayRect = Rect.zero;
        [Ignore]
        private Bounds bounds = new Bounds();
        [Ignore]
        public string classCode;

        protected virtual void OnEnable()
        {
            m_activity = 0;
            BuildReflectionCache();
        }

        public virtual void OnPropertyChange()
        {

        }

        protected virtual void OnDisable()
        {

        }

        protected virtual void LateUpdate()
        {

        }

        protected virtual bool DontSnap
        {
            get { return false; }
        }

        public virtual string LinkName(KitFieldInfo fieldInfo)
        {
            string result = "m_currentValue";
            if (fieldInfo != null && fieldInfo.attribute != null)
            {
                if (fieldInfo.attribute is CommandAttribute)
                {
                    result = "event";
                }

            }
            return result;
        }

        [ExecuteInEditMode]
        protected virtual void Update()
        {
            m_lastActivity = m_activity;
            m_activity -= Time.deltaTime * GizmoHelper.ActivityFadeDuration;
            m_activity = Mathf.Clamp01(Activity);
#if (UNITY_EDITOR)
            if (!Application.isPlaying && !DontSnap)
            {
                Vector3 localPosition = transform.localPosition;
                localPosition.x = Mathf.Round(localPosition.x / KitSettings.GridSize) * KitSettings.GridSize;
                localPosition.y = Mathf.Round(localPosition.y / KitSettings.GridSize) * KitSettings.GridSize;
                transform.localPosition = localPosition;
            }
#endif
        }

        public string[] Messages()
        {
            return m_messages.Messages;
        }

        #region Gizmo Display Code
        //Fields
        [Ignore]
        float nextPos = 0;
        [Ignore]
        float offset = 0;
        [HideInInspector]
        public bool hideGizmos = false;
        [HideInInspector]
        public bool currentlySelected = false;

        //Properties
        protected abstract GizmoHelper.PartType PartType { get; }
        public bool IsCacheBuilt { get; private set; }

        public Bounds WindowBounds
        {
            get
            {

                bounds.center = windowDisplayRect.center - windowDisplayRect.size / 2f;
                bounds.size = windowDisplayRect.size;
                return bounds;
            }
        }

        public float LastActivity
        {
            get
            {
                return m_lastActivity;
            }

            set
            {
                m_lastActivity = value;
            }
        }

        public GizmoHelper.PartType GetPartType()
        {
            return PartType;
        }

        protected virtual void DrawGizmos()
        {
        }

        /// <summary>
        /// Draws custom gizmos (if any) for the component
        /// </summary>
        /// <returns>True if the standard gizmos should be hidden</returns>
        public virtual bool DrawSpecialisedGizmos()
        {
            return false;
        }

        public void SetGizmoSelected(bool isSelected)
        {
            ////if (!IsCacheBuilt)
            BuildReflectionCache();
            KitComponent[] bits = GetComponentsInChildren<KitComponent>();
            for (int i = 0; i < bits.Length; i++)
            {
                bits[i].currentlySelected = isSelected;
                if (!bits[i].IsCacheBuilt)
                    bits[i].BuildReflectionCache();
            }
            //lastState = isHidden;
        }







        #endregion

        #region Reflection Code
        /// <summary>
        /// Builds the reflection caches of inputs, outputs etc..
        /// </summary>
        public void BuildReflectionCache()
        {
            m_commands.Clear();
            m_inputs.Clear();
            m_settings.Clear();
            m_outputs.Clear();
            m_default.Clear();
            m_affecting.Clear();

            classCode = this.GetType().ToString().ToUpper();

            SummaryAttribute summary = (SummaryAttribute)Attribute.GetCustomAttribute(this.GetType(), typeof(SummaryAttribute));
            if (summary != null)
            {
                //m_summary = TextLookup.GetText( "SUM_" + classCode);
                m_summary = summary.Summary;
            }
            else
            {
                //Debug.LogErrorFormat(WM.NO_SUMMARY, GetType().Name);
                m_summary = TextLookup.GetText("SUM_" + classCode);
            }

            if (this is ActiveKitComponent)
            {
                //Add "Event" field.
                KitFieldInfo eventField = new KitFieldInfo(null, this);
                eventField.LinkName = "event";
                eventField.Edge = KitFieldInfo.BoxEdge.Right;
                m_outputs.Add(eventField);
            }

            Type t = this.GetType();
            FieldInfo[] allFields = t.GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);

            for (int i = 0; i < allFields.Length; i++)
            {
                FieldInfo fi = allFields[i];


                if (fi != null)
                {
                    bool include = true;
                    KitFieldInfo kfi = new KitFieldInfo(fi, this);

                    if (fi.IsPublic)
                    {
                        HideInInspector hide = Attribute.GetCustomAttribute(fi, typeof(HideInInspector)) as HideInInspector;
                        if (hide != null)
                            include = false;
                    }
                    if (fi.IsPrivate)
                    {
                        SerializeField show = Attribute.GetCustomAttribute(fi, typeof(SerializeField)) as SerializeField;
                        if (show != null)
                            include = false;
                    }


                    CKitFieldAttribute attrib = (CKitFieldAttribute)Attribute.GetCustomAttribute(fi, typeof(CKitFieldAttribute));
                    if (attrib != null)
                    {
                        if (attrib is DynamicInputAttribute || attrib is OptionAttribute)
                        {

                            if (t.Name.Contains("Variable") || t.Name.Contains("Store"))
                            {
                                m_inputs.Add(kfi);
                            }
                        }

                        else if (attrib is InputAttribute)
                        {
                            
                            if (attrib.Tooltip == null || attrib.Tooltip == "")
                            {
                             attrib.Tooltip = TextLookup.GetText("IN_" + classCode + "_" + fi.Name.ToUpper());
                            }
                            //TODO: Make this work, tooltip property is fixed readonly

                            m_inputs.Add(kfi);
                        }
                        else if (attrib is SettingAttribute)
                        {
                            m_settings.Add(kfi);
                        }
                        else if (attrib is DebugAttribute)
                        {
                            m_default.Add(kfi);
                        }
                        else if (attrib is AffectsAttribute)
                        {
                            m_affecting.Add(kfi);
                        }
                        //else if (attrib is MessageAttribute)
                        //{
                        //    m_message.Add(kfi.FieldName);
                        //}
                        else if (attrib is CommandAttribute)
                        {
                            m_commands.Add(kfi);
                        }
                        else if (attrib is IgnoreAttribute)
                        {
                        }
                        else if (attrib is OutputAttribute)
                        {
                            m_outputs.Add(kfi);
                        }
                        else
                        {
                            Debug.LogWarningFormat(WM.NO_ATTRIBUTE, kfi.FieldName, t.ToString());
                        }
                    }
                    else if (include)
                    {
                        Debug.LogWarningFormat(WM.NO_ATTRIBUTE, kfi.FieldName, t.ToString());
                    }
                }
                LayoutGUINodes(this);
                IsCacheBuilt = true;
            }



        }

        private static void LayoutGUINodes(KitComponent kc)
        {
            int nodeRowPointer = 0;

            List<KitFieldInfo> leftHandFields = new List<KitFieldInfo>();
            leftHandFields.AddRange(kc.m_commands);
            if (kc.m_commands.Count > 0)
            {
                //Insert a blank line.
                leftHandFields.Add(null);

            }
            leftHandFields.AddRange(kc.m_inputs);


            for (int i = 0; i < leftHandFields.Count; i++)
            {
                KitFieldInfo currentField = leftHandFields[i];
                if (currentField != null)
                {
                    if (!(currentField.attribute is OptionAttribute))
                    {
                        nodeRowPointer++;

                        currentField.LinkName = kc.LinkName(currentField);

                        currentField.Edge = KitFieldInfo.BoxEdge.Left;
                        currentField.Order = nodeRowPointer;


                    }
                }
            }

            nodeRowPointer = 0;
            List<KitFieldInfo> rightHandFields = new List<KitFieldInfo>();
            rightHandFields.AddRange(kc.m_outputs);
            if (kc.m_affecting.Count > 0)
            {

                rightHandFields.Add(null);
                rightHandFields.AddRange(kc.m_affecting);
            }

            for (int i = 0; i < rightHandFields.Count; i++)
            {
                nodeRowPointer++;
                KitFieldInfo currentField = rightHandFields[i];
                if (currentField != null)
                {
                    currentField.Edge = KitFieldInfo.BoxEdge.Right;
                    currentField.Order = nodeRowPointer;
                }
            }

        }

        [HideInInspector]
        public string m_summary = null;

        [HideInInspector]
        public List<KitFieldInfo> m_commands = new List<KitFieldInfo>();
        [HideInInspector]
        public List<KitFieldInfo> m_inputs = new List<KitFieldInfo>();
        [HideInInspector]
        public List<KitFieldInfo> m_settings = new List<KitFieldInfo>();
        [HideInInspector]
        public List<KitFieldInfo> m_outputs = new List<KitFieldInfo>();
        [HideInInspector]
        public List<KitFieldInfo> m_default = new List<KitFieldInfo>();
        [HideInInspector]
        public List<KitFieldInfo> m_affecting = new List<KitFieldInfo>();
        [HideInInspector]
        public InspectorMessageList m_messages = new InspectorMessageList();

        #endregion


    }
}


