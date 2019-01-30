using Anglia.CGTech.CKit.Data;
using Anglia.CGTech.CKit.Helper;
using UnityEngine;

namespace Anglia.CGTech.CKit.Functions
{
    [AddComponentMenu(MN.COMP+"Strings")]
    [Summary(HD.FN_EQUAL)]
    public class CompareStrings : BooleanValue
    {

        [SerializeField]
        [Input(TT.IN_STR)]
        private StringValue m_firstString;
        [SerializeField]
        [Input(TT.IN_STR)]
        private StringValue m_secondString;
        [SerializeField]
        [Setting(TT.COMP_MODE)]
        private Comparisons m_mode = Comparisons.AEqualsB;

        protected override GizmoHelper.PartType PartType
        {
            get
            {
                return GizmoHelper.PartType.ProcessActive;
            }
        }

        public override bool Fetch()
        {
            m_currentValue = false;
            if (m_firstString != null && m_secondString != null)
            {
                string firstString = m_firstString.Fetch();
                string secondString = m_secondString.Fetch();
                if (firstString != null && secondString != null)
                {
                    switch (m_mode)
                    {
                        case Comparisons.AEqualsB:
                            m_currentValue = firstString.Equals(secondString);
                            break;
                        case Comparisons.AApproximatelyB:
                            m_currentValue = firstString.ToUpper().Equals(secondString.ToUpper());
                            break;
                        default:
                            Debug.LogWarningFormat(WM.MODE_UNSUPPORTED, m_mode.ToString(), GetType().Name, gameObject.name);
                            break;

                    }

                }
            }
            return m_currentValue;
        }


    }
}
