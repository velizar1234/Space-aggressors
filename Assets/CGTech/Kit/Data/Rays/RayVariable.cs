
using Anglia.CGTech.CKit.Helper;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Anglia.CGTech.CKit.Data
{
    [Summary(HD.RAY_VAR)]
    [AddComponentMenu(MN.VAR+"Ray")]
    public class RayVariable : RayValue {

        [SerializeField]
        [Input(TT.IN_STORE_SOURCE)]
        private RayValue m_source;

        protected override GizmoHelper.PartType PartType
        {
            get
            {
                return GizmoHelper.PartType.Storage;
            }
        }

        protected override GenericDataSource<Ray2D> Source
        {
            get
            {
                return m_source;
            }
        }

        public Ray Ray2Dto3D(Ray2D ray2D)
        {
            Ray result = new Ray();
            result.origin = new Vector3(ray2D.origin.x, ray2D.origin.y, 0f);
            result.direction = new Vector3(ray2D.direction.x, ray2D.direction.y, 0f);
            return result;
        }

        public override Ray2D Fetch()
        {
            Calculate();
            return base.Fetch();
        }

        public void Calculate()
        {
            if (m_source != null)
                m_currentValue = m_source.Fetch();
            else
            {
                m_currentValue.direction = Vector2.zero;
                m_currentValue.origin = Vector2.zero;
            }
        }
    }
}