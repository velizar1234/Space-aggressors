using Anglia.CGTech.CKit.Data;
using Anglia.CGTech.CKit.Helper;
using UnityEngine;

namespace Anglia.CGTech.CKit.Conversion
{
    [AddComponentMenu(MN.IntToFloat)]
    [Summary(HD.INT_2_FLOAT)]
    public class IntToFloat : FloatingPointValue
    {
//pwdCS0219
        [Input(TT.IN_INT)]
        public IntegerValue m_Source;
//pwrCS0219

        public override float Fetch()
        {
            if (m_Source != null)
            {
                m_currentValue = Calculate();
                Activity = m_Source.Activity;
            }
            return m_currentValue;
        }

        protected float Calculate()
        {
            float result = 0;
            bool wasCalculated = false;
            if (m_Source != null)
            {

                result = (float)m_Source.Fetch();
                wasCalculated = true;

            }

            if (wasCalculated)
            {
                m_currentValue = result;
            }
            
            return m_currentValue;
        }

        protected override GizmoHelper.PartType PartType
        {
            get
            {
                return GizmoHelper.PartType.ProcessPassive;
            }
        }



    }
}