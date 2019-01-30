using Anglia.CGTech.CKit.Data;
using Anglia.CGTech.CKit.Helper;
using UnityEngine;

namespace Anglia.CGTech.CKit.Functions
{
    [Summary(HD.FN_COS)]
    [SerializeField]
    [AddComponentMenu("Construction Kit/Math/Cosine")]
    public class CosFunction : FunctionKitComponent
    {
        [SerializeField]
        [Input(TT.IN_FLOAT_DEG)]
        private FloatingPointValue m_source;

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
            if (m_source != null)
            {
                m_currentValue = Mathf.Cos(m_source.Fetch() * Mathf.Deg2Rad);
            }
            SendCommandSignal();
        }
    }
}
