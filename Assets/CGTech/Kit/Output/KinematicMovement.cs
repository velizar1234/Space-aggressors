using Anglia.CGTech.CKit.Data;
using Anglia.CGTech.CKit.Helper;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Anglia.CGTech.CKit.Output
{
    [AddComponentMenu("Construction Kit/Effect/Kinematic Movement")]
    [Summary(HD.MOVE_KINEM)]
    public class KinematicMovement : KitComponent
    {

        [SerializeField]
        [Input(TT.IN_VEC_VEL)]
        private VectorValue m_targetDirection;
        [SerializeField]
        [Affects(TT.IN_GOB_AFF)]
        private GameObject m_ObjectToMove;
        //[SerializeField]
        private float m_speed = 1f;


        protected override void Update()
        {
            base.Update();
            if (m_ObjectToMove != null && m_targetDirection != null)
            {
                Vector2 displacement = m_targetDirection.Fetch() * m_speed * Time.deltaTime;
                m_ObjectToMove.transform.position += new Vector3(displacement.x, displacement.y, 0f);
            }
        }

        #region Helpful functionality code, it is not essential to understand at level 4
        protected override GizmoHelper.PartType PartType
        {
            get
            {
                return GizmoHelper.PartType.Effect;
            }
        }
        protected override void DrawGizmos()
        {
            if (m_ObjectToMove != null)
            {
                GizmoHelper.DrawArrow(transform.position, m_ObjectToMove.transform.position,
                    GizmoHelper.KitType.GameObject);
            }
            if (m_targetDirection != null)
            {
                GizmoHelper.DrawArrow(m_targetDirection.transform.position, transform.position,
                    GizmoHelper.KitType.Vector);
            }
        }
        #endregion
    }
}
