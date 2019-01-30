using Anglia.CGTech.CKit.Data;
using Anglia.CGTech.CKit.Helper;
using UnityEngine;

namespace Anglia.CGTech.CKit.Functions
{
    [AddComponentMenu("Construction Kit/Convert/Make Vector")]
    [Summary(HD.FLOAT_2_VEC)]
    public class MakeVector : FunctionKitComponent
    {

        [SerializeField]
        [Input(TT.IN_FLOAT_X)]
        private FloatingPointValue m_x;
        [SerializeField]
        [Input(TT.IN_FLOAT_Y)]
        private FloatingPointValue m_y;

        [Setting(TT.VEC_NORM)]
        public bool normalise = false;

        [SerializeField]
        [Output(TT.OUT_CURRENT_VAL)]
        private Vector2 m_currentValue;

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


            float countSetInputs = 0;
            if (m_x != null)
                countSetInputs++;
            if (m_y != null)
                countSetInputs++;

            if (countSetInputs == 2)
            {
                m_currentValue = new Vector2(m_x.Fetch(), m_y.Fetch());
            }
            else if (countSetInputs > 0)
            {
                Debug.LogWarningFormat("Either {1} or none of the axis inputs to Combine to Vector on {0} must be linked", gameObject.name, 2);
            }
            if (normalise)
                m_currentValue.Normalize();


        }





    }
}