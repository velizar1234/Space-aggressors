using Anglia.CGTech.CKit.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Anglia.CGTech.CKit.Data
{
    public abstract class VectorValue : GenericDataSource<Vector2>
    {


        protected override void LateUpdate()
        {
#if UNITY_EDITOR
            Fetch();
#endif
            base.LateUpdate();
        }
    }
}
