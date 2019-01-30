using Anglia.CGTech.CKit.Helper;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Anglia.CGTech.CKit.Data;

namespace Anglia.CGTech.CKit.Output
{
    [AddComponentMenu("Construction Kit/Effect/Play Animation")]
    [Summary(HD.PLAY_ANIM)]
    public class PlayAnimation : KitComponent
    {
        
        [SerializeField]
        [Input(TT.IN_TRG_PLAY)]
        private BooleanValue m_trigger;
        [SerializeField]
        [Affects(TT.IN_TGT_COMP)]
        private Animation m_animation;

        protected override GizmoHelper.PartType PartType
        {
            get
            {
                return GizmoHelper.PartType.Effect;
            }
        }

        protected override void DrawGizmos()
        {
            if (m_trigger != null)
                GizmoHelper.DrawArrow(m_trigger.transform.position, transform.position, GizmoHelper.KitType.Boolean);
            if (m_animation != null)
                GizmoHelper.DrawArrow(transform.position, m_animation.transform.position, GizmoHelper.KitType.GameObject);
        }


        protected override void Update()
        {
            base.Update();
            if (m_trigger != null && m_animation != null)
            {
                if (m_trigger.Fetch())
                {
                    m_animation.Play();
                }
            }


        }
    }
}

