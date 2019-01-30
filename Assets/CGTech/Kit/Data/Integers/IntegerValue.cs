using Anglia.CGTech.CKit.Helper;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Anglia.CGTech.CKit.Data
{
    public abstract class IntegerValue : GenericDataSource<int>
    {
        public override int Add(int other)
        {
            int result  = (other);
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

