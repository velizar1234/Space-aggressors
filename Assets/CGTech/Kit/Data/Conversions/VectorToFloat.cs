using Anglia.CGTech.CKit.Data;
using Anglia.CGTech.CKit.Helper;
using UnityEngine;

namespace Anglia.CGTech.CKit.Conversion
{
    [AddComponentMenu(MN.VectorToFloat)]
    public class VectorToFloat : FloatingPointValue
    {
        internal enum Ordinate
        {
            X,
            Y
        }

        [Input(TT.IN_INT)]
        public VectorValue m_Source;

        [Setting]
        private Ordinate m_ordinateChoice = Ordinate.X;

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
                if (m_ordinateChoice == Ordinate.X)
                    result = m_Source.Fetch().x;
                else
                    result = m_Source.Fetch().y;
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