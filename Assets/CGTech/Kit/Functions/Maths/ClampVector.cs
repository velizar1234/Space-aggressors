using System;
using Anglia.CGTech.CKit.Data;
using Anglia.CGTech.CKit.Helper;
using UnityEngine;
namespace Anglia.CGTech.CKit.Functions
{
    [AddComponentMenu("Construction Kit/Math/Clamp Vector")]
    [Summary(HD.FN_CLAMP)]
    public class ClampVector : FunctionKitComponent
    {
        [Input(TT.IN_VEC)]
        public VectorValue m_Input;
        [Input(TT.BOUND_LOW)]
        public VectorValue m_lowerBound;
        [Input(TT.BOUND_UP)]
        public VectorValue m_upperBound;

         
        [SerializeField]
        [Output(TT.OUT_CURRENT_VAL)]
        private Vector2 m_currentValue;

        protected override GizmoHelper.PartType PartType
        {
            get
            {
                return GizmoHelper.PartType.ProcessActive;
            }
        }
        internal override void InvokeProcess()
        {
            base.InvokeProcess();
            m_currentValue = Calculate();
            SendCommandSignal();
        }

        protected Vector2 Calculate()
        {
            float x = 0f, y = 0f;
            bool wasCalculated = false;
            if (m_Input != null && m_upperBound != null && m_lowerBound != null)
            {

                x = Mathf.Clamp(m_Input.Fetch().x, m_lowerBound.Fetch().x, m_upperBound.Fetch().x);
                y = Mathf.Clamp(m_Input.Fetch().y, m_lowerBound.Fetch().y, m_upperBound.Fetch().y);
                wasCalculated = true;

            }

            if (wasCalculated)
            {
                m_currentValue = new Vector2(x, y);
            }
            else
            {
                m_currentValue = Vector2.zero;
            }
            return m_currentValue;
        }




        #region Helpful functionality code, it is not essential to understand at level 4
        //protected override void DrawGizmos()
        //{
        //    if (m_Input != null)
        //    {
        //        GizmoHelper.DrawArrow(m_Input.transform.position, transform.position, GizmoHelper.KitType.Float);
        //    }
        //    if (m_upperBound != null)
        //    {
        //        GizmoHelper.DrawArrow(m_upperBound.transform.position, transform.position, GizmoHelper.KitType.Float);
        //    }
        //    if (m_lowerBound != null)
        //    {
        //        GizmoHelper.DrawArrow(m_lowerBound.transform.position, transform.position, GizmoHelper.KitType.Float);
        //    }
        //}



        #endregion
    }
}