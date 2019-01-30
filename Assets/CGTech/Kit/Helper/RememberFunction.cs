using Anglia.CGTech.CKit.Data;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Anglia.CGTech.CKit.Helper
{
    public abstract class RememberFunction : FunctionKitComponent
    {
        private const int IN_OPT = 1;

        [DynamicInput(TT.IN_KIT_FUNC + TT.IN_GEN_OPTION_A, IN_OPT)]
        [SerializeField]
        protected ActiveKitComponent m_functionSource;

        [Option(TT.TODO, 1)]
        public List<string> m_attachedToOutput = new List<string>();

        [Affects(TT.AFF_TGT_LOC, typeof(int))]
        [SerializeField]
        protected GameObjectValue m_findUnderObject;

        [Ignore]
        protected KitFieldInfo kfi = null;

        [SerializeField]
        [HideInInspector]
        [Ignore]
        private int[] optionChoices = new int[10];

        [Ignore]
        private List<KitFieldInfo> kfiList = null;

        protected override GizmoHelper.PartType PartType
        {
            get
            {
                return GizmoHelper.PartType.ProcessActive;
            }
        }

        protected ActiveKitComponent FunctionSource
        {
            get
            {
                return m_functionSource;
            }
        }


        public int[] OptionChoices
        {
            get
            {
                return optionChoices;
            }

            set
            {
                optionChoices = value;

            }
        }

        public abstract Type MyType();

        public override string LinkName(KitFieldInfo fieldInfo)
        {
            string result = base.LinkName(fieldInfo);
            if (fieldInfo.attribute is DynamicInputAttribute)
            {
                DynamicInputAttribute dynamicAttrib = ((DynamicInputAttribute)fieldInfo.attribute);
                if (dynamicAttrib != null)
                {
                    if (kfiList != null)
                        if (optionChoices != null && (optionChoices.Length > dynamicAttrib.CodeNumber))
                            result = kfiList[optionChoices[dynamicAttrib.CodeNumber]].FieldName;
                }
            }
            return result;
        }

        [ExecuteInEditMode]
        protected override void OnEnable()
        {
            base.OnEnable();
            BindFunctionSourceField();

        }

        protected void BindFunctionSourceField()
        {
            if (m_functionSource != null)
            {
                m_functionSource.BuildReflectionCache();
                kfiList = m_functionSource.m_outputs.FindAll(t => t.DataType == MyType());
                //Debug.Log(kfi);
                if (kfiList != null)
                {
                    m_attachedToOutput.Clear();
                    for (int i = 0; i < kfiList.Count; i++)
                    {
                        m_attachedToOutput.Add(kfiList[i].FieldName);
                    }
                    kfi = kfiList[optionChoices[IN_OPT]];
                    //m_message.Add("Function Source Linked Property is " + kfi.FieldName);
                }
                else
                {
                    Debug.LogErrorFormat(WM.IN_NO_SRC_FOUND, m_functionSource.name, GetType().Name, gameObject.name, MyType().Name);
                }

            }
        }
    }

    public abstract class RememberFunction<T> : RememberFunction
    {
    
        protected abstract GenericDataSource<T> ValueSource { get; set; }
        protected abstract GenericDataSource<T> Target { get; set; }
        

        internal override void InvokeProcess()
        {
            base.InvokeProcess();
            BindFunctionSourceField();
            // New

            if (m_findUnderObject != null)
            {
                m_messages.Display(WM.TAR_FIND_UNDER, m_findUnderObject.name);
                GameObject found = m_findUnderObject.Fetch();
                if (found != null)
                {
                    GenericDataSource<T> target = found.GetComponentInChildren<GenericDataSource<T>>();
                    if (target != null)
                    {
                        Target = target;
                        m_messages.Hide(WM.TAR_MISSING_COMPONENT);
                        m_messages.Display(WM.TAR_TARGET_FOUND, Target.name);
                        
                    }
                    else
                    {
                        m_messages.Display(WM.TAR_MISSING_COMPONENT, typeof(GenericDataSource<T>).ToString());
                    }
                }
            }
            else
            {
                m_messages.Hide(WM.TAR_FIND_UNDER);
            }
            if (Target != null)
            {
                
                if (FunctionSource != null && Target != null)
                {
                    if (ValueSource != null)
                    {
                        m_messages.Display(WM.IN_FN_SOURCE_CLASH);
                        ValueSource = null;
                    }
                    else
                    {
                        m_messages.Hide(WM.IN_FN_SOURCE_CLASH);
                    }
                    object ob = kfi.rawFieldInfo.GetValue(FunctionSource);
                    if (ob != null && ob is T)
                    {
                        Target.CurrentValue = (T)ob;
                    }
                }

                if (ValueSource != null)
                {
                    Target.CurrentValue = ValueSource.Fetch();
                }
            }
            else
            {
                m_messages.Hide(WM.TAR_FIND_UNDER);
            }
            SendCommandSignal();
        }
    }
}
