using Anglia.CGTech.CKit.Data;
using Anglia.CGTech.CKit.Helper;
using UnityEngine;
using UnityEngine.UI;

namespace Anglia.CGTech.CKit.UI
{
    [AddComponentMenu(MN.UI + "Display Text")]

    public class DisplayText : FunctionKitComponent
    {

        [SerializeField]
        [Input(TT.IN_INT)]
        private StringValue m_Source;

        [SerializeField]
        [Affects(TT.IN_TGT_COMP)]
        private Text m_textField;


        internal override void InvokeProcess()
        {
            base.InvokeProcess();

            if (m_Source != null)
            {
                if (m_textField != null)
                {
                    m_textField.text = m_Source.Fetch();
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
