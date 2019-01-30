using Anglia.CGTech.CKit.Data;
using Anglia.CGTech.CKit.Helper;
using System;
using UnityEngine;

namespace Anglia.CGTech.CKit.Maths
{
    [AddComponentMenu(MN.VECTOR_LERP)]
    [Summary(HD.FN_LERP_VEC)]
    public class VectorLerp : VectorValue
    {

        [Input(TT.IN_VEC0)]
        public VectorValue guidePoint0;

        [Input(TT.IN_VEC1)]
        public VectorValue guidePoint1;

        [Input(TT.IN_FACTOR)]
        public FloatingPointValue targetFactor;

        [SerializeField]
        [Range(0f, 1f)]
        [Debug(TT.DEBUG)]
        private float m_currentPositionValue01 = 0.5f;


        public override Vector2 Fetch()
        {

            m_currentValue = Calculate();
            return m_currentValue;
        }

        protected Vector2 Calculate()
        {
            if (guidePoint0 != null && guidePoint1 != null && targetFactor != null)
            {
                //float deviation = (targetFactor.Fetch() - m_currentPositionValue01);
                {
                    m_currentPositionValue01 = targetFactor.Fetch();
                }
                m_currentPositionValue01 = Mathf.Clamp01(m_currentPositionValue01);

                m_currentValue = Vector2.Lerp(guidePoint0.Fetch(), guidePoint1.Fetch(), m_currentPositionValue01);
            }
            else
            {
                Debug.LogWarningFormat(WM.IN_NULL, GetType().Name, gameObject.name);
            }
            return m_currentValue;
        }


    }

}

