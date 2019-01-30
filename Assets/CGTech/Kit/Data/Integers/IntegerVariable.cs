using Anglia.CGTech.CKit.Helper;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Anglia.CGTech.CKit.Data
{
    /// <summary>
    /// The Integer Store component holds an integer (whole) value.  
    /// </summary>
    [AddComponentMenu(MN.IntegerVariable)]
    [Summary(HD.INT_STORE + HD.VARIABLE)]
    public class IntegerVariable : IntegerValue
    {
        
        [SerializeField]
        [Input(TT.IN_STORE_SOURCE)]
        private IntegerValue m_source;

        protected override GizmoHelper.PartType PartType
        {
            get
            {
                return GizmoHelper.PartType.Storage;
            }
        }

        protected override GenericDataSource<int> Source
        {
            get
            {
                return m_source;
            }
        }
    }
}