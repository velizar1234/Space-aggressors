using Anglia.CGTech.CKit.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Anglia.CGTech.CKit.Helper;
using UnityEngine;

namespace Anglia.CGTech.Kit.Functions
{
    [AddComponentMenu("Construction Kit/Math/Normalise Vector")]
    [Summary(HD.FN_NORM_VEC)]
    public class NormaliseVector : VectorValue
    {

        [Input(TT.IN_VEC)]
        [SerializeField]
        private VectorValue m_source;

        //[Output(TT.OUT_CURRENT_VAL)]
        //[SerializeField]
        //private Vector2 m_currentValue;


        protected override GizmoHelper.PartType PartType
        {
            get
            {
                return GizmoHelper.PartType.ProcessActive;
            }
        }

        public override Vector2 Fetch()
        {

            if (m_source != null)
            {
                m_currentValue = m_source.Fetch().normalized;
            }

            return m_currentValue;
        }
    }
}
