using Anglia.CGTech.CKit.Helper;
using System;
using UnityEngine;

namespace Anglia.CGTech.CKit.Data
{
    [Summary(HD.STORE_STR)]
    public class StoreString : RememberFunction<string>
    {

//pwdCS0219
        [Input(TT.IN_BOOL)]
        [SerializeField]
        private StringValue m_variableSource;

        [Affects(TT.AFF_INT_VAR, typeof(string))]
        [SerializeField]
        private StringValue m_target;
//pwrCS0219

        public override Type MyType()
        {
            return typeof(string);
        }

        protected override GenericDataSource<string> ValueSource
        {
            get
            {
                return m_variableSource;
            }

            set
            {
                m_variableSource = value as StringValue;
            }
        }

        protected override GenericDataSource<string> Target
        {
            get
            {
                return m_target;
            }

            set
            {
                m_target = value as StringValue;
            }
        }

        //internal override void InvokeProcess()
        //{
        //    base.InvokeProcess();
        //    if (FunctionSource != null && m_target != null)
        //    {
        //        if (m_variableSource != null)
        //        {
        //            m_messages.Display("Function source overrides variable source on StoreInteger");
        //            m_variableSource = null;
        //        }
        //        object ob = kfi.rawFieldInfo.GetValue(FunctionSource);
        //        if (ob != null && ob is int)
        //        {
        //            m_target.CurrentValue = (string)ob;
        //        }
        //    }
        //    if (m_variableSource != null && m_target != null)
        //        m_target.CurrentValue = m_variableSource.Fetch();
        //    SendCommandSignal();
        //}
    }
}


