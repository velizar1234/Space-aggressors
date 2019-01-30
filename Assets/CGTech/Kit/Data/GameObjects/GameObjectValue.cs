using Anglia.CGTech.CKit.Helper;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Anglia.CGTech.CKit.Data
{
    public abstract class GameObjectValue : GenericDataSource<GameObject>
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
