using Anglia.CGTech.CKit.Helper;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Anglia.CGTech.CKit.Data
{
    public abstract class BooleanValue : GenericDataSource<bool>
    {

        //public abstract bool Fetch(bool force = false);

        //[SerializeField]
        //[Output(TT.OUT_CURRENT_VAL)]
        //protected bool m_currentValue;


        protected override void Update()
        {
            if (m_currentValue)
                Activity = Mathf.Max(Activity, GizmoHelper.ActivityMediumValue);
            base.Update();

        }

        protected override void LateUpdate()
        {
#if UNITY_EDITOR
            Fetch();
#endif
            base.LateUpdate();
        }
    }
}
