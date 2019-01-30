using Anglia.CGTech.CKit.Data;
using Anglia.CGTech.CKit.Helper;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Anglia.CGTech.CKit.Output
{
    [AddComponentMenu(MN.SET_VALUE_VECTOR)]
    [Summary(HD.SET_VALUE)]
    public class SetValueOfVector : FunctionKitComponent
    {
        [SerializeField]
        [Input(TT.IN_VEC)]
        private VectorValue m_source;
        [SerializeField]
        [Affects(TT.EFF_GOS)]
        private GameObjectValue m_targetObject;
        protected override GizmoHelper.PartType PartType
        {
            get
            {
                return GizmoHelper.PartType.ProcessActive;
            }
        }

        internal override void InvokeProcess()
        {
            base.InvokeProcess();
            if (m_targetObject != null && m_source != null)
            {
                GameObject gob = m_targetObject.Fetch();
                if (gob != null)
                {

                    GenericDataSource<Vector2> variable = gob.GetComponent<GenericDataSource<Vector2>>();
                    if (variable != null)
                    {
                        variable.CurrentValue = m_source.Fetch();
                    }

                }
            }
            SendCommandSignal();
        }
    }
}