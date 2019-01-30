using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Anglia.CGTech.CKit.Helper;
using Anglia.CGTech.CKit.Data;

namespace Anglia.CGTech.CKit.Events
{
    [Summary(HD.FN_FRAME_COUNTER)]
    public class EveryNTimes : FunctionKitComponent
    {
        [Input(TT.IN_INT_COUNT)]
        [SerializeField]
        private IntegerValue m_count;


        [Output(TT.OUT_CURRENT_VAL)]
        [SerializeField]
        private int m_currentValue = 0;

        public int Value
        {
            get
            {
                return m_currentValue;
                
            }
            set
            {
                m_currentValue = value;
            }
        }

        internal override void InvokeProcess()
        {
            base.InvokeProcess();
            if (m_count != null)
            {
                m_currentValue++;
                if (m_currentValue > m_count.Fetch())
                {
                    m_currentValue = 0;
                    SendCommandSignal(false);
                }
            }
            else
            {
                //m_message = "An input value is required";
            }
        }

        protected override GizmoHelper.PartType PartType
        {
            get
            {
                return GizmoHelper.PartType.ProcessActive;
            }
        }
    }
}