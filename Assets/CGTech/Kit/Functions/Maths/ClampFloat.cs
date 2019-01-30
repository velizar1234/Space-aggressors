using System;
using Anglia.CGTech.CKit.Data;
using Anglia.CGTech.CKit.Helper;
using UnityEngine;
namespace Anglia.CGTech.CKit.Functions
{
    [AddComponentMenu("Construction Kit/Math/Clamp Floating Point")]
    [Summary(HD.FN_CLAMP)]
    public class ClampFloat : FunctionKitComponent
    {
        [Input(TT.IN_FLOAT)]
        public FloatingPointValue m_Input;
        [Input(TT.BOUND_LOW)]
        public FloatingPointValue m_lowerBound;
        [Input(TT.BOUND_UP)]
        public FloatingPointValue m_upperBound;
        [SerializeField]

        [Output(TT.OUT_CURRENT_VAL)]
        public float m_currentValue;

        internal override void InvokeProcess()
        {
            base.InvokeProcess();
            m_currentValue = Calculate();
            SendCommandSignal();
        }

        protected float Calculate()
        {
            float result = 0f;
            bool wasCalculated = false;
            if (m_Input != null && m_upperBound != null && m_lowerBound != null)
            {

                result = Mathf.Clamp(m_Input.Fetch(), m_lowerBound.Fetch(), m_upperBound.Fetch());
                wasCalculated = true;

            }

            if (wasCalculated)
            {
                m_currentValue = result;
            }
            else
            {
                m_currentValue = float.NaN;
            }
            return m_currentValue;
        }



        #region Helpful functionality code, it is not essential to understand at level 4
        protected override GizmoHelper.PartType PartType
        {
            get
            {
                return GizmoHelper.PartType.ProcessActive;
            }
        }
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