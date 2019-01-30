using Anglia.CGTech.CKit.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Anglia.CGTech.CKit.Helper;
using System;

namespace Anglia.CGTech.CKit.Functions
{
    [AddComponentMenu("Construction Kit/Math/Reset to Grid")]
    [Summary(HD.FN_RESET_GRID)]
    public class ResetToGrid : VectorValue
    {
        [SerializeField]
        [Input(TT.IN_VEC)]
        VectorValue m_source;
        [SerializeField]
        [Input(TT.IN_ACT_BOOL)]
        BooleanValue m_isActive;
        [SerializeField]
        [Setting(TT.IN_SPC_X)]
        float m_xSpacing = 1f;
        [SerializeField]
        [Setting(TT.IN_SPC_Y)]
        float m_ySpacing = 1f;
        [SerializeField]
        [Setting(TT.DEBUG)]
        FloatIntConversion m_roundingMode = FloatIntConversion.Round;
        [SerializeField]
        [Setting(TT.DEBUG)]
        [Range(0.01f, 1f)]
        float m_restoreSpeedFactor = 0.5f;


        protected override GizmoHelper.PartType PartType
        {
            get
            {
                return GizmoHelper.PartType.ProcessActive;
            }
        }

        public override Vector2 Fetch()
        {
            if (!m_calculatedThisFrame)
            {
                m_calculatedThisFrame = true;
                if (m_isActive == null || m_isActive.Fetch())
                {
                    if (m_source != null)
                    {
                        Vector2 closestPosition = Vector2.zero;
                        Vector2 realPosition = m_source.Fetch();
                        switch (m_roundingMode)
                        {
                            case FloatIntConversion.Round:
                                closestPosition.x = Mathf.Round((realPosition.x / m_xSpacing)) * m_xSpacing;
                                closestPosition.y = Mathf.Round((realPosition.y / m_ySpacing)) * m_ySpacing;
                                break;
                            default:
                                Debug.LogWarningFormat(WM.MODE_UNSUPPORTED, m_roundingMode, GetType().Name, gameObject.name);
                                break;
                        }
                        m_currentValue = Vector2.Lerp(realPosition, closestPosition, m_restoreSpeedFactor);
                    }
                }
            }
            return m_currentValue;
        }

        protected override void DrawGizmos()
        {
            if (m_isActive != null)
            {
                GizmoHelper.DrawArrow(m_isActive.transform.position, transform.position, GizmoHelper.KitType.Boolean);
            }
            if (m_source != null)
            {
                GizmoHelper.DrawArrow(m_source.transform.position, transform.position, GizmoHelper.KitType.Vector);
            }
        }
    }
}