using System;
using Anglia.CGTech.CKit.Data;
using Anglia.CGTech.CKit.Helper;
using UnityEngine;

namespace Anglia.CGTech.CKit.Functions
{
    [AddComponentMenu("Construction Kit/Math/Negate Floating Point")]
    [Summary(HD.FN_NEG_FLOAT)]
    public class NegativeFloatingPoint : FloatingPointValue
    {


        [Input(TT.IN_FLOAT)]
        public FloatingPointValue m_source;


        
        protected float Calculate()
        {
            float result = 0f;

            if (m_source != null)
            {
                result = -m_source.Fetch();
            }

            m_currentValue = result;
            return result;
        }

    }
}

