using Anglia.CGTech.CKit.Data;
using Anglia.CGTech.CKit.Helper;
using UnityEngine;

namespace Anglia.CGTech.CKit.Conversion
{
    [AddComponentMenu(MN.FloatToColor)]
    [Summary(HD.FN_FLOAT_2_COL)]
    public class FloatToColor : FunctionKitComponent
    {
//pwdCS0219
        [SerializeField]
        [Input(TT.IN_FLOAT_HUE)]
        private FloatingPointValue m_hueSource;

        [SerializeField]
        [Input(TT.IN_FLOAT_SAT)]
        private FloatingPointValue m_satSource;

        [SerializeField]
        [Input(TT.IN_FLOAT_VAL)]
        private FloatingPointValue m_valSource;

        [SerializeField]
        [Input(TT.IN_FLOAT_ALPHA)]
        private FloatingPointValue m_alphaSource;

        [Output(TT.OUT_CURRENT_VAL)]
        [SerializeField]
        private Color m_currentValue;
//pwrCS0219

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
        
            if (m_satSource != null
                && m_hueSource != null
                && m_valSource != null
                && m_alphaSource != null)
            {
                Color newValue = Color.HSVToRGB(Mathf.Clamp01(m_hueSource.Fetch()),
                        Mathf.Clamp01(m_satSource.Fetch()),
                        Mathf.Clamp01(m_valSource.Fetch()));
                newValue.a = (byte)(Mathf.Clamp01(m_alphaSource.Fetch()) * 255f);
                m_currentValue = newValue;
            }
            else
            {
                Debug.LogWarningFormat(WM.IN_NULL, GetType().Name, gameObject.name);
            }
            SendCommandSignal();
        }


    }
}
