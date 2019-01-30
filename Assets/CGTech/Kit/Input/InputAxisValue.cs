using Anglia.CGTech.CKit.Data;
using Anglia.CGTech.CKit.Helper;
using UnityEngine;

namespace Anglia.CGTech.CKit.Input
{
    [AddComponentMenu("Construction Kit/Input/Axis Value")]
    [Summary(HD.INP_AXIS)]
    public class InputAxisValue : FunctionKitComponent
    {

        [SerializeField]
        [Setting(TT.AXIS_NAME)]
        private string m_AxisName = "";
        [SerializeField]
        [Setting(TT.ST_UNSMOOTH)]
        private bool m_useRawValue = false;

        [SerializeField]
        [Output(TT.OUT_CURRENT_VAL)]
        private float m_currentValue;


        protected override GizmoHelper.PartType PartType
        {
            get
            {
                return GizmoHelper.PartType.ProcessActive;
            }
        }

        internal override void InvokeProcess()
        {
            base.InvokeProcess();

            if (m_AxisName != "")
            {
                m_currentValue = Calculate();
            }
            SendCommandSignal();
        }

        protected float Calculate()
        {
            float axisValue;
            if (m_useRawValue)
                axisValue = UnityEngine.Input.GetAxisRaw(m_AxisName);
            else
                axisValue = UnityEngine.Input.GetAxis(m_AxisName);
            m_currentValue = axisValue;
            return axisValue;
        }

    }


}
