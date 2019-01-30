using Anglia.CGTech.CKit.Data;
using Anglia.CGTech.CKit.Helper;
using UnityEngine;

namespace Assets.CGTech.Kit.Functions
{
    [AddComponentMenu(MN.DISC+"Find String Value")]
    
    public class DiscoverStringValue : StringValue
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

        public override string Fetch()
        {

            if (m_source != null)
            {
                GameObject gob = m_source.Fetch();
                if (gob != null)
                {
                    StringValue source = gob.GetComponent<StringValue>();
                    if (source != null)
                        m_currentValue = source.Fetch();
                    else
                        m_currentValue = "";
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
