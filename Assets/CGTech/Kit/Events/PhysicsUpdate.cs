
using Anglia.CGTech.CKit.Helper;
using UnityEngine;
namespace Anglia.CGTech.CKit.Events
{
    [Summary(HD.EV_EACH_FIXED)]
    [AddComponentMenu(MN.FixedUpdate)]
    public class PhysicsUpdate : CommandSignal
    {
        [SerializeField]
        [Output(TT.OUT_CURRENT_VAL)]
        protected float m_fixedStepDuration;

        protected override GizmoHelper.PartType PartType
        {
            get
            {
                return GizmoHelper.PartType.Event;
            }
        }

        protected void FixedUpdate()
        {
            if (Application.isPlaying)
            {
                SendCommandSignal(false, TriggerArgs.CommandType.Reset);
                m_fixedStepDuration = Time.fixedDeltaTime;
                SendCommandSignal();
            }
        }

        protected override void Update()
        {
            base.Update();

            
        }

    }

}
