using Anglia.CGTech.CKit.Helper;
using System;
using UnityEngine;

namespace Anglia.CGTech.CKit.Data
{
    [AddComponentMenu(MN.STORE_FLOAT_VARIABLE)]
    [Summary(HD.STORE_FLOAT)]
    public class StoreFloatingPoint : RememberFunction<float>
    {
        public override Type MyType()
        {
            return typeof(float);
        }

        [Input(TT.IN_FLOAT)]
        [SerializeField]
        private FloatingPointValue m_variableSource;

        [Affects(TT.AFF_FLOAT_VAR, typeof(float))]
        [SerializeField]
        private FloatingPointValue m_target;

        protected override GenericDataSource<float> ValueSource
        {
            get
            {
                return m_variableSource;
            }

            set
            {
                m_variableSource = value as FloatingPointValue;
            }
        }

        protected override GenericDataSource<float> Target
        {
            get
            {
                return m_variableSource;
            }

            set
            {
                m_variableSource = value as FloatingPointValue;
            }
        }

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
                if (ob != null && ob is float)
                {
                    m_target.CurrentValue = (float)ob;
                }
            }
            if (m_variableSource != null && m_target != null)
                m_target.CurrentValue = m_variableSource.Fetch();
            SendCommandSignal();
        }
    }

}