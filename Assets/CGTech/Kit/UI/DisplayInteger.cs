using Anglia.CGTech.CKit.Data;
using Anglia.CGTech.CKit.Helper;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Anglia.CGTech.CKit.UI
{
    [AddComponentMenu(MN.UI + "Display Integer")]
    [Summary(HD.DISP_INT)]
    public class DisplayInteger : FunctionKitComponent
    {

        [SerializeField]
        [Input(TT.IN_INT)]
        private IntegerValue m_Source;

        [SerializeField]
        [Affects(TT.IN_TGT_COMP)]
        private Text m_textField;

        [SerializeField]
        [Setting]
        private string m_formatString = "##0";


        internal override void InvokeProcess()
        {
            base.InvokeProcess();

            if (m_Source != null)
            {
                if (m_textField != null)
                {
                    m_textField.text = m_Source.Fetch().ToString(m_formatString);
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
