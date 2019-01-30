using Anglia.CGTech.CKit.Helper;
using System;
using UnityEngine;

namespace Anglia.CGTech.CKit.Data
{
    [AddComponentMenu(MN.STORE_BOOL_VARIABLE)]
    [Summary(HD.STORE_BOOL)]
    public class StoreBoolean : RememberFunction<bool>
    {
        public override Type MyType()
        {
            return typeof(bool);
        }

        [Input(TT.IN_BOOL)]
        [SerializeField]
        private BooleanValue m_variableSource;

        [Affects(TT.AFF_INT_VAR, typeof(bool))]
        [SerializeField]
        private BooleanValue m_target;

        internal override void InvokeProcess()
        {
            base.InvokeProcess();
            if (FunctionSource != null && m_target != null)
            {
                if (m_variableSource != null)
                {
                    m_messages.Display("Function source overrides variable source on StoreInteger");
                    m_variableSource = null;
                }
                object ob = kfi.rawFieldInfo.GetValue(FunctionSource);
                if (ob != null && ob is int)
                {
                    m_target.CurrentValue = (bool)ob;
                }
            }
            if (m_variableSource != null && m_target != null)
                m_target.CurrentValue = m_variableSource.Fetch();
            SendCommandSignal();
        }

        protected override GenericDataSource<bool> ValueSource
        {
            get
            {
                return m_variableSource;
            }

            set
            {
                m_variableSource = value as BooleanValue;
            }
        }

        protected override GenericDataSource<bool> Target
        {
            get
            {
                return m_target;
            }

            set
            {
                m_target = value as BooleanValue;
            }
        }
    }
}