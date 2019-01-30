using Anglia.CGTech.CKit.Data;
using Anglia.CGTech.CKit.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Anglia.CGTech.Kit.Output
{
    [AddComponentMenu("Construction Kit/Effect/Point Towards")]
    [Summary(HD.EF_POINT)]
    public class PointTowards : FloatingPointValue
    {
        [SerializeField]
        GameObjectValue m_objectToTrack;
        [SerializeField]
        GameObjectValue m_objectToAffect;
        [SerializeField]
        AttachmentMode m_targetAttachMode = AttachmentMode.Target;

        protected override GizmoHelper.PartType PartType
        {
            get
            {
                return GizmoHelper.PartType.Effect;
            }
        }

        public override float Fetch()
        {
            if (!m_calculatedThisFrame)
            {
                m_calculatedThisFrame = true;
                GameObject affect = PickTarget(m_targetAttachMode, m_objectToAffect);
                if (m_objectToTrack != null && affect != null)
                {
                    GameObject target = m_objectToTrack.Fetch();
                    
                    if (target != null && affect != null)
                    {
                        Vector3 direction = target.transform.position - affect.transform.position;
                        m_currentValue = Quaternion.LookRotation(Vector3.forward, direction).eulerAngles.z;
                    }
                }
                else
                {
                    Debug.LogWarningFormat(WM.IN_NULL, GetType().Name, gameObject.name);
                }
            }
            return m_currentValue;
        }
    }
}
