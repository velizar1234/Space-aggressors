
using Anglia.CGTech.CKit.Helper;
using UnityEngine;
namespace Anglia.CGTech.CKit.Events
{
    [Summary(HD.EV_EACH_FRAME)]
    [AddComponentMenu(MN.EachFrame)]
    public class FrameUpdate : CommandSignal
    {
        [SerializeField]
        [Output(TT.OUT_CURRENT_VAL)]
        protected float m_frameDuration;

        protected override GizmoHelper.PartType PartType
        {
            get
            {
                return GizmoHelper.PartType.Event;
            }
        }

        protected override void Update()
        {
            base.Update();

            if (Application.isPlaying)

            {
                SendCommandSignal(false, TriggerArgs.CommandType.Reset);
                m_frameDuration = Time.deltaTime;
                SendCommandSignal();
            }
        }

    }
    
}
