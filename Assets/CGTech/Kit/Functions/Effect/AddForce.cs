using Anglia.CGTech.CKit.Data;
using Anglia.CGTech.CKit.Helper;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Anglia.CGTech.CKit.Effect
{
    [AddComponentMenu("Effect/Add Force")]
    [Summary(HD.EF_SET_POS)]
    public class AddForce : FunctionKitComponent
    {
        [Input("Force to apply")]
        public VectorValue m_force;
        [Affects("Object to affect")]
        public RigidBodyValue m_objectToAffect;
        internal override void InvokeProcess()
        {
            base.InvokeProcess();
            if (m_objectToAffect != null && m_force != null)
            {
                Rigidbody2D rigidbody = m_objectToAffect.Fetch();
                Vector2 force = m_force.Fetch();
                if (rigidbody != null)
                {
                    rigidbody.AddForce(force);
                }
            }
        }
    }
}