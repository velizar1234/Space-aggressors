using Anglia.CGTech.CKit.Data;
using Anglia.CGTech.CKit.Helper;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Anglia.CGTech.CKit.Output
{
    [Summary(HD.EF_SET_VEL)]
    [AddComponentMenu("Construction Kit/Effect/Set Velocity")]
    public class SetVelocity : FunctionKitComponent
    {
        
        [SerializeField]
        [Input(TT.IN_VEC_VEL)]
        private VectorValue m_velocity;
        [SerializeField]
        [Affects(TT.TGT_RB2)]
        private RigidBodyValue m_target;
        //[SerializeField]
        //[Setting(TT.ST_ALLOW_CHANGE)]
        //private bool m_allowChange = true;
        [SerializeField]
        [Debug(TT.DEBUG)]
        private Vector2 m_currentVelocity = Vector2.zero;


        internal override void InvokeProcess()
        {
            base.InvokeProcess();
            if (m_velocity != null && m_target != null && m_target.Fetch() != null)
            {
                Vector2 newValue = m_velocity.Fetch();
                if (newValue != m_currentVelocity)
                {
                    m_currentVelocity = newValue;
                    m_target.Fetch().velocity = m_currentVelocity;
                }
            }
        }

        //public override bool Fetch()
        //{
        //    if (!m_calculatedThisFrame && (!m_currentValue || m_allowChange))
        //    {
        //        m_calculatedThisFrame = true;
        //        if (m_velocity != null && m_target != null)
        //        {
        //            Vector2 newValue = m_velocity.Fetch();
        //            if (newValue != m_currentVelocity)
        //            {
        //                m_currentVelocity = newValue;
        //                m_target.velocity = m_currentVelocity;
        //                m_currentValue = true;
        //            }
        //        }
        //    }
        //    return m_currentValue;
        //}


        protected override GizmoHelper.PartType PartType
        {
            get
            {
                return GizmoHelper.PartType.Effect;
            }
        }

//        protected override void DrawGizmos()
//        {

//            if (m_target != null)
//            {
//                GizmoHelper.DrawArrow(transform.position, m_target.transform.position, GizmoHelper.KitType.GameObject);
//            }
//            if (m_velocity != null)
//            {
//                GizmoHelper.DrawArrow(m_velocity.transform.position, transform.position, GizmoHelper.KitType.Vector);
//            }

//        }

//        protected override void LateUpdate()
//        {
////#if UNITY_EDITOR
//            Fetch();
////#endif
//            base.LateUpdate();
//        }


    }
}
