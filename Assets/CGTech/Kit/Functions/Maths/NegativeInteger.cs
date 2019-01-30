using System;
using Anglia.CGTech.CKit.Data;
using Anglia.CGTech.CKit.Helper;
using UnityEngine;

namespace Anglia.CGTech.CKit.Functions
{
    [AddComponentMenu(MN.FN_NEG_INT)]
    [Summary(HD.FN_NEG_INT)]
    public class NegativeInteger : IntegerValue
    {


        [Input(TT.IN_FLOAT)]
        public IntegerValue m_source;

        protected float Calculate()
        {
            int result = int.MinValue;

            if (m_source != null)
            {
                result = -m_source.Fetch();
            }

            m_currentValue = result;
            return result;
        }

    }
}

