using System;
using Anglia.CGTech.CKit.Data;
using Anglia.CGTech.CKit.Helper;
using UnityEngine;
using Anglia.CGTech.CKit.Helper.Superclasses;

namespace Anglia.CGTech.CKit.Functions
{
    [AddComponentMenu(MN.FN_ADD_FLOAT)]
    [Summary(HD.FN_ADD)]
    public class FloatAddition : AdditionComponent<FloatingPointValue,float>
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
