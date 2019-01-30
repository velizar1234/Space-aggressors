using Anglia.CGTech.CKit.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Anglia.CGTech.CKit.Helper;
using System;


// Edited by: MM
// Date edited: 15-02-2018

namespace Anglia.CGTech.CKit.Data
{
    /// <summary>
    /// The Floating Point Variable component holds a float (decimal) value.  
    /// If an input source is provided, the store will hold the latest value output by that source.
    /// </summary>
    [AddComponentMenu(MN.FloatVariable)]
    [Summary(HD.FLOAT_STORE + HD.VARIABLE)]
    public class FloatVariable : FloatingPointValue
    {
        [SerializeField]
        [Input(TT.IN_STORE_SOURCE)]
        private FloatingPointValue m_source;

        protected override GizmoHelper.PartType PartType
        {
            get
            {
                return GizmoHelper.PartType.Storage;
            }
        }
        protected override GenericDataSource<float> Source
        {
            get
            {
                return m_source;
            }
        }

    }
}
