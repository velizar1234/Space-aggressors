using Anglia.CGTech.CKit.Helper;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Anglia.CGTech.CKit.Data
{
    public abstract class FloatingPointValue : GenericDataSource<float>
    {
        public override float Add(float other)
        {
            float result = (other);
            result += Fetch();
            return result;
        }

        protected override void LateUpdate()
        {
#if UNITY_EDITOR
            Fetch();
#endif
            base.LateUpdate();
        }
    }


}
