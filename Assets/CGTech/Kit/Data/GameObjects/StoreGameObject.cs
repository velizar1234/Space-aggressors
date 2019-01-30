using Anglia.CGTech.CKit.Helper;
using System;
using UnityEngine;

namespace Anglia.CGTech.CKit.Data
{
    [Summary(HD.STORE_GOB)]
    public class StoreGameObject : RememberFunction<GameObject>
    {
        [Input(TT.IN_GOS)]
        [SerializeField]
        private GameObjectValue m_variableSource;

        [Affects(TT.IN_GOB_AFF, typeof(GameObject))]
        [SerializeField]
        private GameObjectValue m_target;

        public override Type MyType()
        {
            return typeof(GameObject);
        }

        protected override GenericDataSource<GameObject> ValueSource
        {
            get
            {
                return m_variableSource;
            }

            set
            {
                m_variableSource = value as GameObjectValue;
            }
        }

        protected override GenericDataSource<GameObject> Target
        {
            get
            {
                return m_target;
            }

            set
            {
                m_target = value as GameObjectValue;
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
        //        if (ob != null && ob is GameObject)
        //        {
        //            m_target.CurrentValue = (GameObject)ob;
        //        }
        //    }
        //    if (m_variableSource != null && m_target != null)
        //        m_target.CurrentValue = m_variableSource.Fetch();
        //    SendCommandSignal();
        //}
    }
}