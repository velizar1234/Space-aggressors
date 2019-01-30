using System;
using Anglia.CGTech.CKit.Data;
using Anglia.CGTech.CKit.Helper;
using UnityEngine;

namespace Anglia.CGTech.CKit.Maths
{
    [AddComponentMenu("Construction Kit/Math/Add vectors together")]
    [Summary(HD.FN_ADD)]
    public class VectorAddition : FunctionKitComponent
    {
        [Input(TT.IN_ADD_ARR)]
        public VectorValue[] m_sources;
         
        [SerializeField]
        [Output(TT.OUT_CURRENT_VAL)]
        private Vector2 m_currentValue;





        #region Helpful functionality code, it is not essential to understand at level 4
        protected override GizmoHelper.PartType PartType
        {
            get
            {
                return GizmoHelper.PartType.ProcessActive;
            }
        }
        #endregion

        internal override void InvokeProcess()
        {
            base.InvokeProcess();
            Vector2 result = Vector2.zero;
            for (int i = 0; i < m_sources.Length; i++)
            {
                if (m_sources[i] != null)
                {
                    result += m_sources[i].Fetch();
                }
            }
            m_currentValue = result;

            SendCommandSignal();
        }




    }
}
