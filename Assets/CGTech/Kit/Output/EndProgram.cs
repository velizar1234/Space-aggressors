using System;
using Anglia.CGTech.CKit.Helper;
using Anglia.CGTech.CKit.Data;
using UnityEngine;

namespace Anglia.CGTech.CKit.Functions
{
    [AddComponentMenu("Construction Kit/Effect/End Program")]
    [Summary(HD.EF_END)]
    public class EndProgram : FunctionKitComponent
    {
        

        protected override GizmoHelper.PartType PartType
        {
            get
            {
                return GizmoHelper.PartType.Effect;
            }
        }

        internal override void InvokeProcess()
        {
            base.InvokeProcess();

            Application.Quit();

        }
    }
}
