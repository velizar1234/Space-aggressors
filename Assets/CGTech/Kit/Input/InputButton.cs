using Anglia.CGTech.CKit.Data;
using Anglia.CGTech.CKit.Helper;
using UnityEngine;

namespace Anglia.CGTech.CKit.Input
{
    [AddComponentMenu("Construction Kit/Input/Button")]
    [Summary(HD.INP_BUTTON)]
    public class InputButton : FunctionKitComponent
    {
        [SerializeField]
        [Setting(TT.AXIS_NAME)]
        public string m_axisName;

        [Output(TT.OUT_CURRENT_VAL)]
        [SerializeField]
        private bool m_currentValue;

        internal override void InvokeProcess()
        {
            base.InvokeProcess();

            bool value = false;
            if (m_axisName != "")
            {

                value = UnityEngine.Input.GetButton(m_axisName);

            }
            m_currentValue = value;

            SendCommandSignal();


        }

        protected override GizmoHelper.PartType PartType
        {
            get
            {
                return GizmoHelper.PartType.Input;
            }
        }



    }
}
