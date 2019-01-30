using Anglia.CGTech.CKit.Data;
using Anglia.CGTech.CKit.Helper;
using UnityEngine;


namespace Anglia.CGTech.CKit.Functions
{
    [AddComponentMenu("Construction Kit/Math/Integer Division")]
    [Summary(HD.FN_INT_DIV)]
    public class IntegerDivision : FunctionKitComponent
    {
        #region Fields
//pwdCS0219
        [SerializeField]
        [Input(TT.IN_INT_NUM)]
        private IntegerValue m_numerator;
        [SerializeField]
        [Input(TT.IN_INT_DIV)]
        private IntegerValue m_divisor;
        [SerializeField]
        [Setting(TT.ST_INT_DIV_MODE)]
        private IntegerDivisionMode m_requestedResult = IntegerDivisionMode.Division;

        [SerializeField]
        [Output(TT.OUT_CURRENT_VAL)]
        private int m_currentValue;

        [SerializeField]
        [Output(TT.OUT_CURRENT_VAL)]
        private int m_remainder;
//pwrCS0219
        #endregion

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

            if (m_numerator != null && m_divisor != null)
            {
                int divisor = m_divisor.Fetch();
                int numer = m_numerator.Fetch();

                if (divisor == 0)
                {
                    Debug.LogErrorFormat(WM.DIVIDE_BY_ZERO, this.GetType().Name, gameObject.name);
                }
                else
                {

                    m_currentValue = numer / divisor;

                    m_remainder = numer % divisor;

                }

            }
            SendCommandSignal();
        }


    }
}
