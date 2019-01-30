using Anglia.CGTech.CKit.Data;
using Anglia.CGTech.CKit.Helper;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Anglia.CGTech.CKit.Output
{
    [Summary(HD.EFF_ROTATION)]
    [AddComponentMenu("Construction Kit/Effect/Set Rotation")]
    public class ApplyRotation: FunctionKitComponent
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
        //[SerializeField]
        //private FloatingPointSource m_rotationSpeed;
        [SerializeField]
        [Affects(TT.EFF_GOS)]
        private GameObjectValue m_objectToAffect;
        [HideInInspector]
        [Message]
        public GameObject gob;


        protected override void OnEnable()
        {
            base.OnEnable();
            IconManager.SetIcon(gameObject, IconManager.LabelIcon.Red);
        }

        internal override void InvokeProcess()
        {
            //base.InvokeProcess();
        
            if (m_objectToAffect != null)
            {
                gob = m_objectToAffect.Fetch();
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
            SendCommandSignal(false);
        }

        #region Helpful functionality code, it is not essential to understand at level 4

        protected override GizmoHelper.PartType PartType
        {
            get
            {
                return GizmoHelper.PartType.Effect;
            }
        }

        protected override void DrawGizmos()
        {
            if (m_objectToAffect != null)
            {
                GizmoHelper.DrawArrow(transform.position, m_objectToAffect.transform.position, GizmoHelper.KitType.GameObject);
            }
            if (m_targetRotationAroundX != null)
            {
                GizmoHelper.DrawArrow(m_targetRotationAroundX.transform.position, transform.position, GizmoHelper.KitType.Vector);
            }
            if (m_targetRotationAroundY != null)
            {
                GizmoHelper.DrawArrow(m_targetRotationAroundY.transform.position, transform.position, GizmoHelper.KitType.Vector);
            }
            if (m_targetRotationAroundZ != null)
            {
                GizmoHelper.DrawArrow(m_targetRotationAroundZ.transform.position, transform.position, GizmoHelper.KitType.Vector);
            }

        }

        #endregion
    }

}

