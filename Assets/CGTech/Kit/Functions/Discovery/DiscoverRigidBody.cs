using Anglia.CGTech.CKit.Data;
using Anglia.CGTech.CKit.Helper;
using UnityEngine;

namespace Assets.CGTech.Kit.Functions
{
    [AddComponentMenu(MN.DS_GOB_RB )]
    [Summary(HD.EXT_GOB_2_RB)]
    public class DiscoverRigidBody : RigidBodyValue
    {

        [SerializeField]
        [Input(TT.TGT_GOS)]
        private GameObjectValue m_source;


        protected override GizmoHelper.PartType PartType
        {
            get
            {
                return GizmoHelper.PartType.Discovery;
            }
        }

        public override Rigidbody2D Fetch()
        {

            if (m_source != null)
            {
                GameObject gob = m_source.Fetch();
                if (gob != null)
                {
                    Rigidbody2D source = gob.GetComponent<Rigidbody2D>();
                    if (source != null)
                        m_currentValue = source;
                    else
                        m_currentValue = null;
                }

            }
            return m_currentValue;
        }

        protected override void DrawGizmos()
        {
            if (m_source != null)
            {
                GizmoHelper.DrawArrow(m_source.transform.position, transform.position, GizmoHelper.KitType.GameObject);
            }
        }


    }
}
