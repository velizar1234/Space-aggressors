using UnityEngine;

namespace Anglia.CGTech.CKit.Data
{
    public abstract class RayValue : GenericDataSource<Ray2D>
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