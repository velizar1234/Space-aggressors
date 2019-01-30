using System;
using Anglia.CGTech.CKit.Data;
using Anglia.CGTech.CKit.Helper;
using UnityEngine;

namespace Anglia.CGTech.CKit.Functions
{
    [AddComponentMenu(MN.FN_ONE_OVER_N)]
    [Summary(HD.FN_ONE_OVER_N)]
    public class OneOverN : FloatingPointValue
    {
        [Input(TT.IN_FLOAT)]
        public FloatingPointValue m_source;

        protected override GizmoHelper.PartType PartType
        {
            get
            {
                return GizmoHelper.PartType.ProcessPassive;
            }
        }


        public override float Fetch()
        {

            m_currentValue = Calculate();
            
            return m_currentValue;
        }


        protected float Calculate()
        {
            float result = 0f;

            if (m_source != null)
            {
                result = 1f / m_source.Fetch();
            }

            m_currentValue = result;
            return result;
        }

    }
}

