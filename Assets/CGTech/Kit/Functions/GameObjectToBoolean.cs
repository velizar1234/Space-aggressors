using Anglia.CGTech.CKit.Data;
using Anglia.CGTech.CKit.Helper;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Anglia.CGTech.CKit.Discovery
{
    [Summary(HD.EXT_GOB_2_BOOL)]
    [AddComponentMenu(MN.DS_GOB_BOOL)]
    public class GameObjectToBoolean : BooleanValue
    {
        
        [SerializeField]
        [Input(TT.TGT_GOS)]
        private GameObjectValue m_Source;


        protected override GizmoHelper.PartType PartType
        {
            get
            {
                return GizmoHelper.PartType.ProcessActive;
            }
        }

        public override bool Fetch()
        {
            if (!m_calculatedThisFrame)
            {
                m_calculatedThisFrame = true;
                m_currentValue = false;
                if (m_Source!=null)
                {
                    GameObject source = m_Source.Fetch();
                    if (source != null)
                    {
                        BooleanValue bs = source.GetComponent<BooleanValue>();
                        if (bs != null)
                        {
                            m_currentValue = bs.Fetch();
                        }
                    }
                }

            }
            return m_currentValue;
        }

        protected override void DrawGizmos()
        {
            if (m_Source != null)
            {
                GizmoHelper.DrawArrow(m_Source.transform.position, transform.position, GizmoHelper.KitType.GameObject);
            }
        }
    }
}
