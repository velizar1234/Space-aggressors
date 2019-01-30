using System;
using Anglia.CGTech.CKit.Data;
using Anglia.CGTech.CKit.Helper;
using UnityEngine;
namespace Anglia.CGTech.CKit.Maths
{
    [AddComponentMenu(MN.ScaleVector)]
    [Summary(HD.FN_SCALE_VC2)]
    public class ScaleVector : FunctionKitComponent
    {
        [Input(TT.IN_FLOAT)]
        public FloatingPointValue m_scaleFactor;
        [Input(TT.IN_VEC)]
        public VectorValue m_vectorSource;
        [SerializeField]
        [Output(TT.OUT_CURRENT_VAL)]
        private Vector2 m_currentValue;

        #region Helpful functionality code, it is not essential to understand at level 4
        protected override GizmoHelper.PartType PartType
        {
            get
            {
                return GizmoHelper.PartType.ProcessActive;
            }
        }


        protected override void DrawGizmos()
        {
            if (m_scaleFactor != null && m_vectorSource != null)
            {
                GizmoHelper.DrawArrow(m_scaleFactor.transform.position, transform.position, GizmoHelper.KitType.Float);
                GizmoHelper.DrawArrow(m_vectorSource.transform.position, transform.position, GizmoHelper.KitType.Vector);
            }

        }
        #endregion
        internal override void InvokeProcess()
        {
            base.InvokeProcess();

        
        
            m_currentValue = Calculate();
            SendCommandSignal();
        }

        protected Vector2 Calculate()
        {
            Vector2 result = Vector2.zero;
            bool wasCalculated = false;

            if (m_scaleFactor != null && m_vectorSource != null)
            {
                result = m_vectorSource.Fetch() * m_scaleFactor.Fetch();
                wasCalculated = true;
            }


            if (wasCalculated)
            {
                m_currentValue = result;
            }
            else
            {
                m_currentValue = Vector2.zero;
            }
            return m_currentValue;
        }



    }
}