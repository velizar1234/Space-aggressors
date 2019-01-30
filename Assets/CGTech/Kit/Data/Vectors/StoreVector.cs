using Anglia.CGTech.CKit.Helper;
using System;
using UnityEngine;

namespace Anglia.CGTech.CKit.Data
{
    [Summary(HD.STORE_VEC)]
    public class StoreVector : RememberFunction<Vector2>
    {
//pwdCS0219
        [Input(TT.IN_GOS)]
        [SerializeField]
        private VectorValue m_variableSource;

        [Affects(TT.IN_GOB_AFF, typeof(GameObject))]
        [SerializeField]
        private VectorValue m_target;
//pwrCS0219

        protected override GenericDataSource<Vector2> ValueSource
        {
            get
            {
                return m_variableSource;
            }

            set
            {
                m_variableSource = value as VectorValue;
            }
        }
        protected override GenericDataSource<Vector2> Target
        {
            get
            {
                return m_target;
            }

            set
            {
                m_target = value as VectorValue;
            }
        }
        public override Type MyType()
        {
            return typeof(Vector2);
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
        //        if (ob != null && ob is Vector2)
        //        {
        //            m_target.CurrentValue = (Vector2)ob;
        //        }
        //    }
        //    if (m_variableSource != null && m_target != null)
        //        m_target.CurrentValue = m_variableSource.Fetch();
        //    SendCommandSignal();
        //}
    }
}