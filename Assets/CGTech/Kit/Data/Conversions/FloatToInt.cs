using Anglia.CGTech.CKit.Data;
using Anglia.CGTech.CKit.Helper;
using UnityEngine;

namespace Anglia.CGTech.CKit.Conversion
{
    [AddComponentMenu(MN.FloatToInt)]
    [Summary(HD.FLOAT_2_INT)]
    public class FloatToInt : IntegerValue
    {
//pwdCS0219
        [Input(TT.IN_FLOAT)]
        public FloatingPointValue m_source;
        [Setting(TT.MODE_F2I)]
        public FloatIntConversion m_mode = FloatIntConversion.Round;
//pwrCS0219



        public override int Fetch()
        {

                m_currentValue = Calculate();
            return m_currentValue;
        }

        protected int Calculate()
        {
            int result = 0;
            bool wasCalculated = false;
            if (m_source != null)
            {
                switch (m_mode)
                {
                    case FloatIntConversion.Floor:
                        result = Mathf.FloorToInt(m_source.Fetch());
                        break;
                    case FloatIntConversion.Ceiling:
                        result = Mathf.CeilToInt(m_source.Fetch());
                        break;
                    case FloatIntConversion.Round:
                        result = Mathf.RoundToInt(m_source.Fetch());
                        break;

                }
                wasCalculated = true;

            }

            if (wasCalculated)
            {
                m_currentValue = result;
            }
            else
            {
                //m_currentValue = output;
            }
            return m_currentValue;
        }



        #region Helpful functionality code, it is not essential to understand at level 4
        protected override GizmoHelper.PartType PartType
        {
            get
            {
                return GizmoHelper.PartType.ProcessPassive;
            }
        }

        protected override void DrawGizmos()
        {
            if (m_source != null)
            {
                GizmoHelper.DrawArrow(m_source.transform.position, transform.position, GizmoHelper.KitType.Float);
            }
            //if (m_upperBound != null)
            //{
            //    GizmoHelper.DrawArrow(m_upperBound.transform.position, transform.position, GizmoHelper.KitType.Float);
            //}
            //if (m_lowerBound != null)
            //{
            //    GizmoHelper.DrawArrow(m_lowerBound.transform.position, transform.position, GizmoHelper.KitType.Float);
            //}


        }



        #endregion
    }
}