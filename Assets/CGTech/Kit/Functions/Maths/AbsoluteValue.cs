using UnityEngine;
using System.Collections;
using Anglia.CGTech.CKit.Helper;
using Anglia.CGTech.CKit.Data;

namespace Anglia.CGTech.CKit.Functions
{
    [AddComponentMenu(MN.MATH + "Absolute Value")]
    public class AbsoluteValue : FunctionKitComponent
    {
        protected override GizmoHelper.PartType PartType
        {
            get
            {
                return GizmoHelper.PartType.ProcessActive;
            }
        }

        [SerializeField]
        [Input]
        private FloatingPointValue m_source;

        [SerializeField]
        [Output(TT.OUT_CURRENT_VAL)]
        private float m_currentValue;
        [SerializeField]
        [Output(TT.SIGN_VALUE)]
        private float m_signValue;

        internal override void InvokeProcess()
        {
            base.InvokeProcess();

            if (m_source != null)
            {
                float source = m_source.Fetch();
                m_currentValue = Mathf.Abs(source);
                m_signValue = Mathf.Sign(source);
            }
            SendCommandSignal();
        }
    }

}