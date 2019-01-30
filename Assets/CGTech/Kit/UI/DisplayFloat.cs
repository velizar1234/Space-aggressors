using Anglia.CGTech.CKit.Data;
using Anglia.CGTech.CKit.Helper;
using UnityEngine;
using UnityEngine.UI;

namespace Anglia.CGTech.CKit.UI
{
    [AddComponentMenu(MN.UI + "Display Float")]
    [Summary(HD.DISP_FLOAT)]
    public class DisplayFloat : FunctionKitComponent
    {

        [SerializeField]
        [Input(TT.IN_FLOAT)]
        private FloatingPointValue m_Source;
        [SerializeField]
        [Setting(TT.ST_FORMAT_CODE)]
        private string m_formatCode = "#,##0.0";
        //[SerializeField]
        //[Input(TT.ST_COLOR)]
        //private ColorValue m_color;
        [SerializeField]
        [Affects(TT.IN_TGT_COMP)]
        private Text m_textField;

        internal override void InvokeProcess()
        {

            base.InvokeProcess();
            if (m_Source != null)
            {
                //if (m_color != null)
                //{
                //    m_textField.color = m_color.Fetch();
                //}

                if (m_textField != null)
                {
                    m_textField.text = m_Source.Fetch().ToString(m_formatCode);
                }
            }
            SendCommandSignal();
        }

        protected override GizmoHelper.PartType PartType
        {
            get
            {
                return GizmoHelper.PartType.Effect;
            }
        }

    }
}

