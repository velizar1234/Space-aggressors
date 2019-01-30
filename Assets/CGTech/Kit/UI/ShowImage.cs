using Anglia.CGTech.CKit.Data;
using Anglia.CGTech.CKit.Helper;
using UnityEngine;
using UnityEngine.UI;

namespace Anglia.CGTech.CKit.UI
{
    [AddComponentMenu("Construction Kit/GUI/Show Image")]
    [Summary(HD.DISP_IMAGE)]
    public class ShowImage : KitComponent
    {

        [SerializeField]
        [Input(TT.IN_BOOL_ONOFF)]
        private BooleanValue m_Source;

        [SerializeField]
        [Input(TT.IN_TGT_COMP)]
        private Image m_image;

        [SerializeField]
        [Input(TT.ST_COLOR)]
        private ColorValue m_color;

        protected override void Update()
        {
            base.Update();
            if (m_image != null)
            {
                if (m_Source != null)
                {
                    m_image.enabled = m_Source.Fetch();
                }
                
                if (m_color != null)
                {
                    m_image.color = m_color.Fetch();
                }
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
            if (m_image != null)
            {
                GizmoHelper.DrawArrow(transform.position, m_image.transform.position, GizmoHelper.KitType.GameObject);
            }
            if (m_Source != null)
            {
                GizmoHelper.DrawArrow(m_Source.transform.position, transform.position, GizmoHelper.KitType.Boolean);
            }

        }
        #endregion
    }
}
