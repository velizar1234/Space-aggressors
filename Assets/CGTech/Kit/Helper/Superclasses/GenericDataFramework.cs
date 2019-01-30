
using Anglia.CGTech.CKit.Helper;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Anglia.CGTech.CKit.Data
{


    public abstract class GenericDataFramework : KitComponent
    {
        public virtual ActiveKitComponent FunctionSource
        {
            get
            {
                return m_functionSource;
            }
            set
            {
                m_functionSource = value;
                BindFunctionSourceField();
            }
        }

        #region Function Source Binding
        const int IN_OPT = 1;
        [SerializeField]
        [DynamicInput(TT.IN_KIT_FUNC + TT.IN_GEN_OPTION_A, IN_OPT)]
        protected ActiveKitComponent m_functionSource;
        [Option(TT.TODO, IN_OPT)]
        public List<string> m_attachedToOutput = new List<string>();
        [Ignore]
        protected KitFieldInfo kfi = null;
        [SerializeField]
        [HideInInspector]
        [Ignore]
        private int[] optionChoices = new int[10];
        [Ignore]
        private List<KitFieldInfo> kfiList = null;

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


        internal void BindFunctionSourceField()
        {
            if (m_functionSource != null)
            {
                m_functionSource.BuildReflectionCache();
                kfiList = m_functionSource.m_outputs.FindAll(t => t.DataType == MyType());

                if (kfiList != null)
                {
                    m_attachedToOutput.Clear();
                    for (int i = 0; i < kfiList.Count; i++)
                    {
                        m_attachedToOutput.Add(kfiList[i].FieldName);
                    }
                    kfi = kfiList[optionChoices[IN_OPT]];

                }
                else
                {
                    Debug.LogErrorFormat(WM.IN_NO_SRC_FOUND, m_functionSource.name, GetType().Name, gameObject.name, MyType().Name);
                }

            }
        }

        public abstract Type MyType();
        public abstract string ValueToString();

        #endregion
    }
}