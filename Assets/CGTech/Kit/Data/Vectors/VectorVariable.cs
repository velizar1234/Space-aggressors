using Anglia.CGTech.CKit.Helper;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Anglia.CGTech.CKit.Data
{
    /// <summary>
    /// The Vector Store component holds a 2D Vector (x,y) value.  
    /// If an input source is provided, the store will hold the latest value output by that source.
    /// </summary>
    [AddComponentMenu(MN.VectorVariable)]
    [Summary(HD.VC2_STORE + HD.VARIABLE)]
    public class VectorVariable : VectorValue
    {
        [SerializeField]
        [Input(TT.IN_STORE_SOURCE)]
        private VectorValue m_source;

        protected override GizmoHelper.PartType PartType
        {
            get
            {
                return GizmoHelper.PartType.Storage;
            }
        }


        //public override Vector2 Fetch()
        //{

        //        if (m_source != null)
        //        {
        //            if (WasValuePushed)
        //            {
        //                Debug.LogErrorFormat(WM.DUAL_INPUT, GetType().Name, gameObject.name);
        //            }
        //            else
        //            {
        //                m_currentValue = m_source.Fetch();
        //            }
        //        }

            

        //    return CurrentValue;
        //}

        protected override GenericDataSource<Vector2> Source
        {
            get
            {
                return m_source;
            }
        }
    }
}
