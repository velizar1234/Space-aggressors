
using Anglia.CGTech.CKit.Helper;
using System;
using UnityEngine;

namespace Anglia.CGTech.CKit.Data
{
    [AddComponentMenu(MN.StoreIntegerVariable)]
    [Summary(HD.STORE_INT)]
    public class StoreInteger : RememberFunction<int>
    {
//pwdCS0219
        [Input(TT.IN_INT + TT.IN_GEN_OPTION_A)]
        [SerializeField]
        private IntegerValue m_variableSource;

        [Affects(TT.AFF_INT_VAR, typeof(int))]
        [SerializeField]
        private IntegerValue m_targetInt;
//pwrCS0219

        protected override GenericDataSource<int> ValueSource
        {
            get
            {
                return m_variableSource;
            }

            set
            {
                m_variableSource = value as IntegerValue;
            }
        }

        protected override GenericDataSource<int> Target
        {
            get
            {
                return m_targetInt;
            }

            set
            {
                m_targetInt = value as IntegerValue;
            }
        }

        public override Type MyType()
        {
            return typeof(int);
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            
        }

    }
}
