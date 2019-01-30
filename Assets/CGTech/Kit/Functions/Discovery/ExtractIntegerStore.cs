using Anglia.CGTech.CKit.Data;
using Anglia.CGTech.CKit.Helper;
using UnityEngine;

namespace Assets.CGTech.Kit.Functions
{
    [AddComponentMenu(MN.DS_GOB_INT)]
    [Summary(HD.EXT_GOB_2_INT)]
    public class DiscoverIntegerValue : IntegerValue
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

        public override int Fetch()
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
