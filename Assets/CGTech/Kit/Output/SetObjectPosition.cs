using Anglia.CGTech.CKit.Data;
using Anglia.CGTech.CKit.Helper;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Anglia.CGTech.CKit.Output
{
    [AddComponentMenu("Construction Kit/Effect/Set Object Position")]
    [Summary(HD.EF_SET_POS)]
    public class SetObjectPosition : KitComponent
    {

        [SerializeField]
        [Input(TT.IN_VEC)]
        private VectorValue m_targetPosition = null;
        [SerializeField]
        [Affects(TT.EFF_GOS)]
        private GameObjectValue m_ObjectToPlace = null;
        [SerializeField]
        [Input(TT.IN_ACT_BOOL)]
        private BooleanValue m_isActive = null;

        [SerializeField]
        [Setting(TT.ST_RESET_PHYS)]
        private bool m_resetPhysics = true;

        protected override void OnEnable()
        {
            base.OnEnable();
            IconManager.SetIcon(gameObject, IconManager.LabelIcon.Red);
        }

        protected override void Update()
        {
            base.Update();
            if (m_ObjectToPlace != null && m_targetPosition != null)
            {
                GameObject objectToPlace = m_ObjectToPlace.Fetch();
                if (objectToPlace != null)
                {
                    if (m_isActive == null || m_isActive.Fetch())
                    {
                        Rigidbody2D rb2D = objectToPlace.GetComponent<Rigidbody2D>();
                        if (rb2D != null && m_resetPhysics)
                        {
                            rb2D.Sleep();
                        }
                        objectToPlace.transform.position = m_targetPosition.Fetch();
                        if (rb2D != null && m_resetPhysics)
                        {
                            rb2D.WakeUp();
                        }
                    }
                }
            }
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
            if (m_ObjectToPlace != null)
            {
                GizmoHelper.DrawArrow(transform.position, m_ObjectToPlace.transform.position, GizmoHelper.KitType.GameObject);
            }
            if (m_targetPosition != null)
            {
                GizmoHelper.DrawArrow(m_targetPosition.transform.position, transform.position, GizmoHelper.KitType.Vector);
            }
            if (m_isActive != null)
                if (m_targetPosition != null)
                {
                    GizmoHelper.DrawArrow(m_isActive.transform.position, transform.position, GizmoHelper.KitType.Boolean);
                }
        }
        #endregion
    }

}

