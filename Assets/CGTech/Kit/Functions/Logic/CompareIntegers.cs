using Anglia.CGTech.CKit.Data;
using Anglia.CGTech.CKit.Helper;
using UnityEngine;

namespace Anglia.CGTech.CKit.Functions
{
    [AddComponentMenu(MN.CompareIntegers)]
    [Summary(HD.FN_COMPARE)]
    public class CompareIntegers : BooleanValue
    {
        
        [SerializeField]
        [Input(TT.IN_INT)]
        private IntegerValue m_valueA;
        [SerializeField]
        [Input(TT.IN_INT)]
        private IntegerValue m_valueB;
        [Setting(TT.COMP_MODE)]
        public Comparisons m_mode = Comparisons.ALessThanB;
         


        public override bool Fetch()
        {
            m_currentValue = false;
            if (m_valueA != null && m_valueB != null)
            {
                float a = m_valueA.Fetch();
                float b = m_valueB.Fetch();
                switch (m_mode)
                {
                    case Comparisons.ALessThanB:
                        m_currentValue = a < b;
                        break;
                    case Comparisons.AEqualsB:
                        m_currentValue = a.Equals(b);
                        break;
                    case Comparisons.AGreaterThanB:
                        m_currentValue = a > b;
                        break;
                    default:
                        Debug.LogWarningFormat(WM.MODE_UNSUPPORTED, m_mode, this.GetType().ToString(), gameObject.name);
                        break;

                }
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
