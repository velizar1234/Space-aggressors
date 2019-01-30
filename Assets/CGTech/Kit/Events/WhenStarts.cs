
using Anglia.CGTech.CKit.Helper;
using UnityEngine;
namespace Anglia.CGTech.CKit.Events
{
    [Summary(HD.STARTUP)]
    [AddComponentMenu(MN.Startup)]
    public class WhenStarts : CommandSignal
    {
        protected override GizmoHelper.PartType PartType
        {
            get
            {
                return GizmoHelper.PartType.Event;
            }
        }

        protected void Start() 
        {
            if (Application.isPlaying)
            {
                SendCommandSignal(false, TriggerArgs.CommandType.Reset);
                SendCommandSignal();
            }
        }

        protected override void Update()
        {
            base.Update();
        }
    }

}
