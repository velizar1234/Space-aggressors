using Anglia.CGTech.CKit.Helper;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Anglia.CGTech.CKit.Data
{
    /// <summary>
    /// The Floating Point Store component holds a float (decimal) value.  
    /// If an input source is provided, the store will hold the latest value output by that source.
    /// </summary>
    [AddComponentMenu("Construction Kit/Data/Floating Point Store")]
    [Summary(HD.FLOAT_STORE)]
    public class FloatingPointStore : FloatingPointValue
    {


        protected override GizmoHelper.PartType PartType
        {
            get
            {
                return GizmoHelper.PartType.Storage;
            }
        }


        public override float Fetch()
        {

            return m_currentValue;
        }
    }
}
