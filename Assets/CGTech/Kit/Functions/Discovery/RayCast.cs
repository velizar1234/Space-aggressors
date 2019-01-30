using Anglia.CGTech.CKit.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Anglia.CGTech.CKit.Helper;
using System;

namespace Anglia.CGTech.CKit.Discovery
{
    [AddComponentMenu(MN.RayCast)]
    [Summary(HD.RAYCAST)]
    public class RayCast : FunctionKitComponent
    {

        [SerializeField]
        [Input(TT.IN_RAY)]
        private RayValue m_ray = null;
        [Ignore]
        private Ray2D ray =new Ray2D();
        [SerializeField]
        [Setting(TT.IN_STR_ARR_TAG)]
        public List<string> m_matchTags = new List<string>(0);

        [Output(TT.OUT_CURRENT_VAL)]
        [SerializeField]
        private GameObject m_currentValue;

        internal override void InvokeProcess()
        {
            base.InvokeProcess();
            bool foundTarget = false;
            m_currentValue = null;
            if (m_ray != null)
            {
                ray = m_ray.Fetch();

                RaycastHit2D[] hitsInfo = Physics2D.RaycastAll(ray.origin,ray.direction);
                for (int i = 0; i < hitsInfo.Length; i++)
                {
                    
                    string currentTag = hitsInfo[i].collider.gameObject.tag;
                    if (m_matchTags.Count == 0)
                    {
                        m_currentValue = hitsInfo[i].collider.gameObject;
                        foundTarget = true;
                    }
                    else
                    {
                        for (int m = 0; m < m_matchTags.Count; m++)
                        {
                            if (m_matchTags[m] == currentTag)
                            {
                                m_currentValue = hitsInfo[i].collider.gameObject;
                                foundTarget = true;
                                break;
                            }
                        }
                    }
                    if (foundTarget)
                    {
                        break;
                    }
                }
                if (!foundTarget)
                {
                    m_currentValue = null;
                }

            }
            SendCommandSignal();
        }

        protected override GizmoHelper.PartType PartType
        {
            get
            {
                return GizmoHelper.PartType.Discovery;
            }
        }

    }
}