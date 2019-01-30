using System;
using Anglia.CGTech.CKit.Data;
using Anglia.CGTech.CKit.Helper;
using UnityEngine;
using Anglia.CGTech.CKit.Helper.Superclasses;

namespace Anglia.CGTech.CKit.Functions
{
    [AddComponentMenu(MN.FN_ADD_INT)]
    [Summary(HD.FN_ADD)]
    public class IntegerAddition : AdditionComponent<IntegerValue,int>
    {

        protected override GizmoHelper.PartType PartType
        {
            get
            {
                return GizmoHelper.PartType.ProcessActive;
            }
        }

    }
}
