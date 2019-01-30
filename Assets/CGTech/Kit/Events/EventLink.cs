using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Anglia.CGTech.CKit.Helper;
using Anglia.CGTech.CKit.Data;

namespace Anglia.CGTech.CKit.Events
{
    [Summary(HD.LINK)]
    [AddComponentMenu(MN.EventLink)]
    public class EventLink : FunctionKitComponent
    {
        internal override void InvokeProcess()
        {
            base.InvokeProcess();
            SendCommandSignal();
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