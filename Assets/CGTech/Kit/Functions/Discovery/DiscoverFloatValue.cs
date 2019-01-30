using Anglia.CGTech.CKit.Data;
using Anglia.CGTech.CKit.Helper;
using UnityEngine;

namespace Assets.CGTech.Kit.Functions
{
    [AddComponentMenu(MN.DISC+ "Find Float Value")]
    public class DiscoverFloatValue : FloatingPointValue
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

        public override float Fetch()
        {

            if (m_source != null)
            {
                GameObject gob = m_source.Fetch();
                if (gob != null)
                {
                    IntegerValue source = gob.GetComponent<IntegerValue>();
                    if (source != null)
                        m_currentValue = source.Fetch();
                    else
                        m_currentValue = 0;
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
