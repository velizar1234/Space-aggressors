using Anglia.CGTech.CKit.Data;
using Anglia.CGTech.CKit.Helper;
using UnityEngine;
using UnityEngine.UI;

namespace Anglia.CGTech.CKit.UI
{
    [AddComponentMenu("Construction Kit/GUI/Show Text")]
    [Summary(HD.DISP_TEXT)]

    public class ShowText : KitComponent
    {
        
        [SerializeField]
        [Input(TT.IN_BOOL_ONOFF)]
        private BooleanValue m_Source;

        [Header("Display Objects")]
        [SerializeField]
        [Input(TT.IN_TGT_COMP)]
        private Text m_textField;

        protected override void Update()
        {
            base.Update();
            if (m_Source != null)
            {
                if (m_textField != null)
                {
                    m_textField.enabled = m_Source.Fetch();
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
            if (m_textField != null)
            {
                GizmoHelper.DrawArrow(transform.position, m_textField.transform.position, GizmoHelper.KitType.GameObject);
            }
            if (m_Source != null)
            {
                GizmoHelper.DrawArrow(m_Source.transform.position, transform.position, GizmoHelper.KitType.Boolean);
            }

        }
        #endregion
    }
}
