using Anglia.CGTech.CKit.Data;
using Anglia.CGTech.CKit.Helper;
using UnityEngine;

namespace Anglia.CGTech.CKit.Events
{
    [AddComponentMenu("Construction Kit/Event/Collision")]
    [Summary(HD.DET_COLL)]
    public class CollisionDetector : ActiveKitComponent
    {
        [SerializeField]
        [Output(TT.OUT_CURRENT_VAL)]
        private GameObject m_currentValue;
        //[SerializeField]
        //[Debug(TT.DEBUG)]
        [Ignore]
        private GameObject m_detectedLast;
        [SerializeField]
        [Output(TT.TODO)]
        public bool m_detected;

        void OnCollisionEnter2D(Collision2D collision2D)
        {
            m_detectedLast = collision2D.gameObject;
            m_currentValue = m_detectedLast;
            m_detected = true;
            SendCommandSignal();
        }

        void OnTriggerEnter2D(Collider2D collider2D)
        {
            m_detectedLast = collider2D.gameObject;
            m_currentValue = m_detectedLast;
            m_detected = true;
            SendCommandSignal();
        }

        void OnCollisionExit2D(Collision2D collision2D)
        {
            m_detectedLast = collision2D.gameObject;
            m_currentValue = null;
            m_detected = false;
        }

        void OnTriggerExit2D(Collider2D collider2D)
        {
            m_detectedLast = collider2D.gameObject;
            m_currentValue = null;
            m_detected = false;
        }

        //public override GameObject Fetch(bool force = false)
        //{
        //    if (!m_calculatedThisFrame)
        //    {
        //        m_calculatedThisFrame = true;
        //        if (m_detected)
        //        {
        //            m_currentValue = m_detectedLast;
        //        }
        //        else
        //            m_currentValue = null;
        //    }
        //    return m_currentValue;
        //}

        #region Helpful functionality code, it is not essential to understand at level 4

        protected override GizmoHelper.PartType PartType
        {
            get
            {
                return GizmoHelper.PartType.Event;
            }
        }

        protected override void DrawGizmos()
        {
            if (m_detectedLast != null)
                GizmoHelper.DrawArrow(transform.position, m_detectedLast.transform.position, GizmoHelper.KitType.GameObject);
        }


        #endregion
    }
}