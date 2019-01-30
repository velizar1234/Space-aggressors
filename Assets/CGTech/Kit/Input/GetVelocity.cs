using Anglia.CGTech.CKit.Data;
using Anglia.CGTech.CKit.Helper;
using UnityEngine;

namespace Anglia.CGTech.CKit.Discovery
{
    [Summary(HD.GET_VEL)]
    public class GetVelocity : VectorValue
    {
        [SerializeField]
        [Input(TT.IN_COMP_SOURCE)]
        private Rigidbody2D m_Source;


        protected override GizmoHelper.PartType PartType
        {
            get
            {
                return GizmoHelper.PartType.Discovery;
            }
        }

        public override Vector2 Fetch()
        {
            if (!m_calculatedThisFrame)
            {
                m_calculatedThisFrame = true;
                {
                    if (m_Source != null)
                    {
                        m_currentValue = m_Source.velocity;
                    }
                }
            }
            return m_currentValue;

        }

        protected override void DrawGizmos()
        {
            if (m_Source != null)
            {
                GizmoHelper.DrawArrow(m_Source.transform.position, transform.position, GizmoHelper.KitType.GameObject);
            }
        }
    }
}