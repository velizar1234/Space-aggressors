using Anglia.CGTech.CKit.Data;
using Anglia.CGTech.CKit.Helper.Library;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;


namespace Anglia.CGTech.CKit.Helper
{
    /// <summary>
    /// Custom Inspector for the Construction Kit components.
    /// </summary>
    [CustomEditor(typeof(KitComponent), true)]
    [CanEditMultipleObjects]
    public class KitComponentEditor : UnityEditor.Editor
    {
        public static float scale;


        KitComponent m_target;
        private int[] optionChoices = new int[10];


        #region Custom Inspector

        void OnEnable()
        {
            m_target = serializedObject.targetObject as KitComponent;
            m_target.BuildReflectionCache();
        }

        /// <summary>
        /// Draws the custom inspector instead of Unity's default.
        /// </summary>
        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            if (m_target is RememberFunction)
            {
                optionChoices = ((RememberFunction)m_target).OptionChoices;
            }

            if (m_target.gameObject.name.Contains("GameObject") || m_target.gameObject.name == "")
            {
                m_target.gameObject.name = ObjectNames.NicifyVariableName(m_target.GetType().Name);
            }
            EditorStyles.label.wordWrap = true;
            EditorGUILayout.Space();
            EditorGUILayout.LabelField(m_target.m_summary);

            DrawSection(m_target.m_commands, CS.TIMING);

            if (m_target != null && m_target.m_inputs != null)
            {
                if (m_target.m_inputs.Count == 1)
                {
                    DrawSection(m_target.m_inputs, CS.INPUT);
                }
                else
                {
                    DrawSection(m_target.m_inputs, CS.INPUTS);
                }
            }

            //Draw Settings
            DrawSection(m_target.m_settings, CS.SETTING);

            //Draw Affectings
            DrawSection(m_target.m_affecting, "Affecting");

            //Draw Outputs
            if (m_target is ActiveKitComponent)
            {
                if (m_target.m_outputs.Count > 1)
                {
                    DrawSection(m_target.m_outputs, CS.OUTPUT);
                }
            }
            else
            {
                //No inspector element for rays, so quick fix is ignore outputs
                //if (m_target.m_outputs.Count > 0 && m_target.m_outputs[0].DataType != typeof(Ray2D))
                DrawSection(m_target.m_outputs, CS.OUTPUT);
            }

            DrawSection(m_target.m_default, CS.DEFAULT);

            //Draw Messages
            DrawSectionReadOnly(m_target.m_messages.Messages, "Information");

            if (m_target is RememberFunction)
            {
                ((RememberFunction)m_target).OptionChoices = optionChoices;
            }


            if (m_target is ActiveKitComponent)
            {
                if (m_target.m_outputs.Count > 1)
                {
                    EditorGUILayout.Space();
                    if (GUILayout.Button("Create Output Var(s)"))
                    {
                        for (int i = 0; i < m_target.m_outputs.Count; i++)
                        {
                            KitFieldInfo currentKFI = m_target.m_outputs[i];
                            if (currentKFI.LinkName != "event")
                            {

                                //currentKFI.
                                GameObject gob = new GameObject(ObjectNames.NicifyVariableName(currentKFI.LinkName));
                                gob.transform.parent = m_target.transform;
                                gob.transform.localPosition = (Vector3.down + Vector3.right) * KitSettings.GridSize * 4;
                                GenericDataFramework genericDataFramework = null;
                                switch (GizmoHelper.ClosestKitType(currentKFI))
                                {
                                    case GizmoHelper.KitType.Boolean:
                                        genericDataFramework = gob.AddComponent<BooleanVariable>();
                                        break;
                                    case GizmoHelper.KitType.Color:
                                        genericDataFramework = gob.AddComponent<ColorVariable>();
                                        break;
                                    case GizmoHelper.KitType.Float:
                                        genericDataFramework = gob.AddComponent<FloatVariable>();
                                        break;
                                    case GizmoHelper.KitType.GameObject:
                                        genericDataFramework = gob.AddComponent<GameObjectVariable>();
                                        break;
                                    case GizmoHelper.KitType.Integer:
                                        genericDataFramework = gob.AddComponent<IntegerVariable>();
                                        break;
                                    case GizmoHelper.KitType.String:
                                        genericDataFramework = gob.AddComponent<StringVariable>();
                                        break;
                                    case GizmoHelper.KitType.Vector:
                                        genericDataFramework = gob.AddComponent<VectorVariable>();
                                        break;
                                    case GizmoHelper.KitType.Ray:
                                        genericDataFramework = gob.AddComponent<RayVariable>();
                                        break;
                                    //case GizmoHelper.KitType.Vector:
                                    //    genericDataFramework = gob.AddComponent<VectorVariable>();
                                    //    break;
                                    //case GizmoHelper.KitType.Vector:
                                    //    genericDataFramework = gob.AddComponent<VectorVariable>();
                                    //    break;
                                    //case GizmoHelper.KitType.Vector:
                                    //    genericDataFramework = gob.AddComponent<VectorVariable>();
                                    //    break;
                                    default:
                                        Debug.LogWarningFormat("Unexpected variable type");
                                        break;
                                }
                                if (genericDataFramework != null)
                                {
                                    genericDataFramework.FunctionSource = m_target as ActiveKitComponent;
                                }
                            }

                        }
                    }
                }
            }
            EditorGUILayout.Space();
            // Now save any changes.
            if (serializedObject.ApplyModifiedProperties())
                m_target.OnPropertyChange();
        }

        private bool DrawSection(List<KitFieldInfo> p_names, string p_heading)
        {
            bool result = false;
            if (p_names != null)
            {
                if (p_names.Count > 0)
                {
                    result = true;
                    EditorGUILayout.Space();
                    FontStyle fs = EditorStyles.label.fontStyle;
                    EditorStyles.label.fontStyle = FontStyle.Bold;
                    EditorGUILayout.LabelField(p_heading);
                    EditorStyles.label.fontStyle = FontStyle.Normal;

                    for (int i = 0; i < p_names.Count; i++)
                    {
                        if (p_names[i] != null)
                        {
                            CKitFieldAttribute attribute = p_names[i].attribute;
                            string currentName = p_names[i].FieldName;
                            if (currentName == "event")
                                continue;
                            SerializedProperty sp = serializedObject.FindProperty(currentName);


                            if (sp != null)
                            {
                                if (attribute is OptionAttribute)
                                {
                                    EditorGUI.indentLevel++;
                                    int index = ((OptionAttribute)attribute).CodeNumber;
                                    optionChoices[index] = EditorList.Show(sp, optionChoices[index]);
                                    EditorGUI.indentLevel--;
                                }
                                else
                                {
                                    if (sp.isArray)
                                    {
                                        sp.isExpanded = true;
                                        EditorGUILayout.PropertyField(sp, true);
                                    }
                                    else
                                    {
                                        GUIContent gc = new GUIContent();
                                        gc.text = ObjectNames.NicifyVariableName(sp.name);
                                        gc.tooltip = attribute.Tooltip;
                                        if (gc.tooltip == "" || gc.tooltip == null)
                                        {
                                            gc.tooltip = TextLookup.GetText(attribute.LookUpCode() + m_target.classCode + "_" + sp.name.ToUpper());
                                        }

                                        //EditorGUILayout.PropertyField(sp)
                                        EditorGUILayout.PropertyField(sp, gc);
                                    }
                                }
                            }
                            else
                            {
                                GUIContent gc = new GUIContent();
                                gc.text = ObjectNames.NicifyVariableName(currentName);
                                gc.tooltip = attribute.Tooltip;
                                string msg = "Value cannot be displayed in Inspector";

                                if (m_target is GenericDataFramework)
                                {
                                    msg = ((GenericDataFramework)m_target).ValueToString();
                                }
                                EditorGUILayout.TextField(gc, msg);
                                //Debug.LogWarning("No field " + currentName);
                            }
                        }
                    }
                }
            }
            return result;
        }

        private bool DrawSectionReadOnly(string[] p_names, string p_heading)
        {
            bool result = false;
            if (p_names.Length > 0)
            {
                result = true;
                EditorGUILayout.Space();
                FontStyle fs = EditorStyles.label.fontStyle;
                EditorStyles.label.fontStyle = FontStyle.Bold;
                EditorGUILayout.LabelField(p_heading);
                EditorStyles.label.fontStyle = FontStyle.Normal;

                for (int i = 0; i < p_names.Length; i++)
                {
                    string currentName = p_names[i];
                    EditorGUILayout.LabelField(currentName);
                }
            }
            return result;
        }

        #endregion


    }
}

