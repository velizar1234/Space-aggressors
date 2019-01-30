using Anglia.CGTech.CKit.Data;
using Anglia.CGTech.CKit.Helper;
using UnityEngine;

namespace Anglia.CGTech.CKit.Events
{
    [AddComponentMenu(MN.EV+"Destruction")]
    
    public class Destruction : ActiveKitComponent
    {

        protected override void OnDestroy()
        {
            SendCommandSignal();
            base.OnDestroy();
        }

        protected override GizmoHelper.PartType PartType
        {
            get
            {
                return GizmoHelper.PartType.Event;
            }
        }

        
    }
}