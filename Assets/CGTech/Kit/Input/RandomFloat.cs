using Anglia.CGTech.CKit.Helper;
using UnityEngine;

namespace Anglia.CGTech.CKit.Maths
{
    [AddComponentMenu("Construction Kit/Input/Random Floating Point")]
    [Summary(HD.RANDOM)]
    public class RandomFloat : FunctionKitComponent
    {
//pwdCS0219
        [SerializeField]
        [Output(TT.OUT_CURRENT_VAL)]
        private float m_currentValue;
        [Ignore]
        private float lastValue = float.NaN;
//pwrCS0219 

        internal override void InvokeProcess()
        {
            base.InvokeProcess();
            
            m_currentValue = UnityEngine.Random.Range(0f, 1f);
           
            SendCommandSignal();
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