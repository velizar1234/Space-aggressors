
using Anglia.CGTech.CKit.Helper;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Anglia.CGTech.CKit.Data
{
    public abstract class RigidBodyValue : GenericDataSource<Rigidbody2D> {

    }

    [AddComponentMenu(MN.RigidbodyVariable)]
    [Summary(HD.RB2_VAR)]
    public class RigidBodyVariable : RigidBodyValue
    {

        [SerializeField]
        [Input("")]
        private RigidBodyValue m_source;

        protected override GizmoHelper.PartType PartType
        {
            get
            {
                return GizmoHelper.PartType.Storage;
            }
        }

        public override Rigidbody2D Fetch()
        {
            if (m_source != null)
            {
                if (WasValuePushed)
                {
                    Debug.LogErrorFormat(WM.DUAL_INPUT, GetType().Name, gameObject.name);
                }
                else
                {
                    m_currentValue = m_source.Fetch();
                }
            }
            return m_currentValue;
        }
    }
}