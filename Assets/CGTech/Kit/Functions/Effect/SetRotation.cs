using Anglia.CGTech.CKit.Data;
using Anglia.CGTech.CKit.Helper;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Anglia.CGTech.CKit.Effect
{
    [Summary(HD.EFF_ROTATION)]
    [AddComponentMenu(MN.SET_ROTATION )]
    public class SetRotation : FunctionKitComponent
    {

        [SerializeField]
        [Input(TT.IN_FLOAT_ROTX)]
        private FloatingPointValue m_targetRotationAroundX;
        [SerializeField]
        [Input(TT.IN_FLOAT_ROTY)]
        private FloatingPointValue m_targetRotationAroundY;
        [SerializeField]
        [Input(TT.IN_FLOAT_ROTZ)]
        private FloatingPointValue m_targetRotationAroundZ;
        [SerializeField]
        [Affects(TT.EFF_GOS)]
        private GameObjectValue m_objectToAffect;

        internal override void InvokeProcess()
        {
            base.InvokeProcess();

            if (m_objectToAffect != null)
            {
                GameObject gob = m_objectToAffect.Fetch();
                if (gob != null)
                {
                    Vector3 rot = Vector3.zero;
                    if (m_targetRotationAroundX != null)
                    {
                        rot.x = m_targetRotationAroundX.Fetch();
                    }
                    if (m_targetRotationAroundY != null)
                    {
                        rot.y = m_targetRotationAroundY.Fetch();
                    }
                    if (m_targetRotationAroundZ != null)
                    {
                        rot.z = m_targetRotationAroundZ.Fetch();
                    }
                    gob.transform.rotation = Quaternion.Euler(rot);
                }

            }
            SendCommandSignal();
        }

        protected override GizmoHelper.PartType PartType
        {
            get
            {
                return GizmoHelper.PartType.Effect;
            }
        }
     
    }

}

