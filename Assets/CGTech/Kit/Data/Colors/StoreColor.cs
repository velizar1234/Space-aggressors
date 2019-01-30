using Anglia.CGTech.CKit.Helper;
using System;
using UnityEngine;

namespace Anglia.CGTech.CKit.Data
{
    [Summary(HD.STORE_VEC)]
    public class StoreColor : RememberFunction<Color>
    {
        [Input(TT.IN_GOS)]
        [SerializeField]
        private ColorValue m_variableSource;

        [Affects(TT.IN_GOB_AFF, typeof(Color32))]
        [SerializeField]
        private ColorValue m_target;

        public override Type MyType()
        {
            return typeof(Color32);
        }

        protected override GenericDataSource<Color> ValueSource
        {
            get
            {
                return m_variableSource;
            }

            set
            {
                m_variableSource = value as ColorValue;
            }
        }

        protected override GenericDataSource<Color> Target
        {
            get
            {
                return m_target;
            }

            set
            {
                m_target = value as ColorVariable;
            }
        }
        //internal override void InvokeProcess()
        //{
        //    base.InvokeProcess();
        //    if (FunctionSource != null && m_target != null)
        //    {
        //        if (m_variableSource != null)
        //        {
        //            String msg = "Function source overrides variable source on Storage Functions";

        //                m_messages.Display(msg);
        //            m_variableSource = null;
        //        }
        //        object ob = kfi.rawFieldInfo.GetValue(FunctionSource);
        //        if (ob != null && ob is Color32)
        //        {
        //            m_target.CurrentValue = (Color32)ob;
        //        }
        //    }
        //    if (m_variableSource != null && m_target != null)
        //        m_target.CurrentValue = m_variableSource.Fetch();
        //    SendCommandSignal();
        //}
    }
}
