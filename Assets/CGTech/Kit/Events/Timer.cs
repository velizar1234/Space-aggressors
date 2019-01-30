using Anglia.CGTech.CKit.Data;
using Anglia.CGTech.CKit.Helper;
using UnityEngine;

namespace Anglia.CGTech.CKit.Events
{
    /// <summary>
    /// The Timer component has an output value of false until a certain time interval has elapsed.
    /// </summary>
    [AddComponentMenu(MN.Timer)]
    [Summary(HD.TIMER)]
    public class Timer : FunctionKitComponent
    {
//pwdCS0219
        [SerializeField]
        [Input(TT.IN_RST_BOOL)]
        private BooleanValue m_Reset = null;

        [SerializeField]
        [Input(TT.IN_FLOAT_DUR)]
        private FloatingPointValue m_Duration = null;

        [SerializeField]
        [Output(TT.OUT_CURRENT_VAL)]
        internal float elapsedTime;
        [Ignore]
        private bool isActive;
//pwrCS0219 

        protected override void Update()
        {
            base.Update();
            if (isActive)
            {
                Activity = 0.2f;
                elapsedTime += Time.deltaTime;
                if (m_Duration != null)
                {
                    if (elapsedTime >= m_Duration.Fetch())
                    {
                        isActive = false;
                        Activity = 1f;
                        SendCommandSignal();
                    }
                }
            }
            else if (m_Reset != null && m_Reset.Fetch())
            {
                elapsedTime = 0f;
                isActive = true;
            }
        }

        internal override void InvokeProcess()
        {
            base.InvokeProcess();
            //TODO: add setting to allow reset only when inactive
            if(!isActive || (m_Reset != null && m_Reset.Fetch()))
            {
                elapsedTime = 0f;
            }
            isActive = true;
        }

        protected override bool DontSnap
        {
            get
            {
                return false;
            }
        }

        

        protected override GizmoHelper.PartType PartType
        {
            get
            {
                return GizmoHelper.PartType.Input;
            }
        }

    }


}
