using Anglia.CGTech.CKit.Helper;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Anglia.CGTech.CKit.Data;

namespace Anglia.CGTech.CKit.Output
{
    [AddComponentMenu("Construction Kit/Effect/Play Audio")]
    [Summary(HD.PLAY_SOUND)]
    public class PlayAudio : KitComponent
    {
        
        [SerializeField]
        [Input(TT.IN_TRG_PLAY)]
        private BooleanValue m_trigger;
        [SerializeField]
        [Affects(TT.IN_TGT_COMP)]
        private AudioSource m_audioSource;

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
            if (m_audioSource != null)
                GizmoHelper.DrawArrow(transform.position, m_audioSource.transform.position, GizmoHelper.KitType.GameObject);
        }


        protected override void Update()
        {
            base.Update();
            if (m_trigger != null && m_audioSource != null)
            {
                if (m_trigger.Fetch())
                {
                    m_audioSource.Play();
                }
            }


        }
    }
}
