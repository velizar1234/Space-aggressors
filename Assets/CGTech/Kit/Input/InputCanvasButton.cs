using Anglia.CGTech.CKit.Data;
using Anglia.CGTech.CKit.Helper;
using System;
using UnityEngine;

namespace Anglia.CGTech.CKit.Input
{
    [AddComponentMenu(MN.CanvasButtonClick)]
    [Summary(HD.INP_CANV_BTN)]
    public class InputCanvasButton : ActiveKitComponent
    {
        public void OnClick()
        {
            SendCommandSignal();
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
