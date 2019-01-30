using Anglia.CGTech.CKit.Data;
using Anglia.CGTech.CKit.Helper;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Anglia.CGTech.CKit.UI
{
    [AddComponentMenu(MN.UI+"Fill by Float")]
    [Summary(HD.DISP_FLOAT_FILL)]
    public class FillByFloat : FunctionKitComponent
    {
        [SerializeField]
        [Input (TT.IN_FLOAT)]
        private FloatingPointValue m_Source;
        [SerializeField]
        [Setting(TT.IN_FILL_MAX)]
        private float m_maximumFillAt = 1f;
        [SerializeField]
        [Affects(TT.IN_TGT_COMP)]
        private Image m_filledImage;


        internal override void InvokeProcess()
        {
            base.InvokeProcess();
            if (m_Source != null)
            {
                if (m_filledImage != null)
                {
                    m_filledImage.fillAmount = m_Source.Fetch()/m_maximumFillAt;
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

