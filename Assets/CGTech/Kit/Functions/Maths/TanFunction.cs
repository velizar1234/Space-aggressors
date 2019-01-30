﻿using Anglia.CGTech.CKit.Data;
using Anglia.CGTech.CKit.Helper;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Anglia.CGTech.CKit.Functions
{
    [Summary(HD.FN_TAN)]
    [SerializeField]
    [AddComponentMenu("Construction Kit/Math/Tangent")]
    public class TanFunction : FunctionKitComponent
    {
        [SerializeField]
        [Input(TT.IN_FLOAT_DEG)]
        private FloatingPointValue m_source;
        [SerializeField]
        [Output(TT.OUT_CURRENT_VAL)]
        protected float m_currentValue;

        protected override GizmoHelper.PartType PartType
        {
            get
            {
                return GizmoHelper.PartType.ProcessActive;
            }
        }
        internal override void InvokeProcess()
        {

            base.InvokeProcess();
            if (m_source != null)
            {
                m_currentValue = Mathf.Tan(m_source.Fetch() * Mathf.Deg2Rad);
            }
            SendCommandSignal();
        }
    }
}