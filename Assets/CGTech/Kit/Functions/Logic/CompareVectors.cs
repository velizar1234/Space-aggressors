using Anglia.CGTech.CKit.Data;
using Anglia.CGTech.CKit.Helper;
using UnityEngine;

namespace Anglia.CGTech.CKit.Functions
{
    [AddComponentMenu(MN.COMP+ "Vectors")]
    [Summary(HD.FN_COMPARE)]
    public class CompareVectors : BooleanValue
    {

        [SerializeField]
        [Input(TT.IN_VEC)]
        private VectorValue m_firstVector;
        [SerializeField]
        [Input(TT.IN_VEC)]
        private VectorValue m_secondVector;
        [SerializeField]
        [Setting(TT.COMP_THRE)]
        [Range(0.001f, 1f)]
        private float m_threshold = 0.25f;
        [SerializeField]
        [Setting(TT.COMP_MODE)]
        private AxesOfComparison m_mode = AxesOfComparison.X;


        public override bool Fetch()
        {
            m_currentValue = false;
            if (m_firstVector != null && m_secondVector != null)
            {
                Vector2 firstVector = m_firstVector.Fetch();
                Vector2 secondVector = m_secondVector.Fetch();
                switch (m_mode)
                {
                    case AxesOfComparison.Distance:
                        m_currentValue = (firstVector - secondVector).sqrMagnitude <= m_threshold * m_threshold;
                        break;
                    case AxesOfComparison.X:
                        m_currentValue = Mathf.Abs(firstVector.x - secondVector.x) <= m_threshold;
                        break;
                    case AxesOfComparison.Y:
                        m_currentValue = Mathf.Abs(firstVector.y - secondVector.y) <= m_threshold;
                        break;
                }
            }
            return m_currentValue;
        }

        #region HFC
        protected override GizmoHelper.PartType PartType
        {
            get
            {
                return GizmoHelper.PartType.ProcessActive;
            }
        }

        protected override void DrawGizmos()
        {
            if (m_firstVector != null)
            {
                GizmoHelper.DrawArrow(m_firstVector.transform.position, transform.position, GizmoHelper.KitType.Vector);
            }

            if (m_secondVector != null)
            {
                GizmoHelper.DrawArrow(m_secondVector.transform.position, transform.position, GizmoHelper.KitType.Vector);
            }


        }


        #endregion
    }
}
