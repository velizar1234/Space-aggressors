using System;
using Anglia.CGTech.CKit.Data;
using Anglia.CGTech.CKit.Helper;
using UnityEngine;
namespace Anglia.CGTech.CKit.Functions
{
    [AddComponentMenu(MN.FN_SCALE_FLOAT)]
    [Summary(HD.FN_SCALE_FLOAT)]
    public class ScaleFloatingPoint : FunctionKitComponent
    {
        [Input(TT.IN_SCALE_ARR)]
        public FloatingPointValue[] m_sources;

        [SerializeField]
        [Output(TT.OUT_CURRENT_VAL)]
        private float m_currentValue;

        #region Helpful functionality code, it is not essential to understand at level 4
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

            float result = 1f;
            bool wasCalculated = false;
            // Debug.Log(m_sources.Length.ToString() + " sources");

            for (int i = 0; i < m_sources.Length; i++)
            {
                // Debug.LogFormat("Source {0} is {1}", i, m_sources[i]);
                if (m_sources[i] != null)
                {
                    float value = m_sources[i].Fetch();
                    result = result * value;
                    //Debug.LogFormat("Value {0} is {1}", i, value);
                    wasCalculated = true;
                }
            }

            if (wasCalculated)
            {
                m_currentValue = result;
                // Debug.Log("Calc:" + m_currentValue);
            }
            else
            {
                m_currentValue = 0f;
            }
            SendCommandSignal();
        }



        #endregion
    }
}