using Anglia.CGTech.CKit.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Anglia.CGTech.CKit.Helper;
using System;

namespace Anglia.CGTech.CKit.Input
{
    [AddComponentMenu("Construction Kit/Input/Mouse Location")]
    [Summary(HD.MOUSE_LOCATION)]
    public class InputMouseLocation : VectorValue
    {
        
        [SerializeField]
        [Setting(TT.IN_TGT_CAM)]
        private Camera m_seenThroughCamera = null;
        [SerializeField]
        [Setting(TT.ST_CURSOR_LOCK)]
        private CursorLockMode m_cursorLock = CursorLockMode.None;

        #region Helper code.
        protected override GizmoHelper.PartType PartType
        {
            get
            {
                return GizmoHelper.PartType.Input;
            }
        }

        protected override void DrawGizmos()
        {
            GizmoHelper.DrawArrow(m_currentValue, transform.position, GizmoHelper.KitType.Vector);
        }
        #endregion

        new void OnEnable()
        {
            base.OnEnable();

                Cursor.lockState = m_cursorLock;
        }

        public override Vector2 Fetch()
        {

                Vector3 mousePos = UnityEngine.Input.mousePosition;
                if (m_seenThroughCamera == null)
                    m_seenThroughCamera = Camera.main;

                if (m_seenThroughCamera != null)
                {
                    mousePos = m_seenThroughCamera.ScreenToWorldPoint(mousePos);
                }
                m_currentValue = new Vector2(mousePos.x, mousePos.y);
            
            return m_currentValue;
        }
    }
}