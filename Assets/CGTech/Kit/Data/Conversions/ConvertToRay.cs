using Anglia.CGTech.CKit.Data;
using Anglia.CGTech.CKit.Helper;
using UnityEngine;

namespace Anglia.CGTech.Kit.Conversion
{
    [AddComponentMenu(MN.CONV + "Vectors to Ray")]
    public class ConvertToRay : RayValue
    {
        [Input]
        [SerializeField]
        private VectorValue origin;

        [Input]
        [SerializeField]
        private VectorValue direction;

        public override Ray2D Fetch()
        {
            if (origin != null && direction != null)
            {
                m_currentValue = new Ray2D(origin.Fetch(), direction.Fetch());
            }
            return m_currentValue;
        }

        
        protected override GizmoHelper.PartType PartType
        {
            get
            {
                return GizmoHelper.PartType.Storage;
            }
        }
    }
}