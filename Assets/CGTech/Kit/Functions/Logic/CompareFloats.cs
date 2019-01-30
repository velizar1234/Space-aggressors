using System;
using Anglia.CGTech.CKit.Data;
using Anglia.CGTech.CKit.Helper;
using UnityEngine;

namespace Anglia.CGTech.CKit.Functions
{
    [AddComponentMenu(MN.FN_COMPARE_FLOAT)]
    [Summary(HD.FN_COMPARE)]
    public class CompareFloats : BooleanValue
    {
        [SerializeField]
        [Input(TT.IN_FLOAT)]
        private FloatingPointValue m_valueA;
        [SerializeField]
        [Input(TT.IN_FLOAT)]
        private FloatingPointValue m_valueB;
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
                        m_currentValue = a<b;
                        break;
                    case Comparisons.AEqualsB:
                        m_currentValue = a.Equals(b);
                        break;
                    case Comparisons.AGreaterThanB:
                        m_currentValue = a > b;
                        break;
                    case Comparisons.AApproximatelyB:
                        m_currentValue = Mathf.Approximately(a,b);
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

        public bool currentVal
        {
            get
            {
                return m_currentValue;
            }
        }


        //protected override void DrawGizmos()
        //{
        //    if (m_valueA != null)
        //    {
        //        GizmoHelper.DrawArrow(m_valueA.transform.position, transform.position, GizmoHelper.KitType.Float);
        //    }

        //    if (m_valueB != null)
        //    {
        //        GizmoHelper.DrawArrow(m_valueB.transform.position, transform.position, GizmoHelper.KitType.Float);
        //    }


        //}
    }
}
