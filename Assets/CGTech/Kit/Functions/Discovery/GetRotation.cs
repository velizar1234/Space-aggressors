using Anglia.CGTech.CKit.Data;
using Anglia.CGTech.CKit.Helper;
using UnityEngine;

namespace Anglia.CGTech.CKit.Functions
{
    [AddComponentMenu("Construction Kit/Discover/Rotation")]
    [Summary(HD.FN_TRANS_2_VEC)]
    public class GetRotation : FunctionKitComponent
    {
        [SerializeField]
        [Input(TT.TGT_GOB)]
        private GameObjectValue m_source;

        [SerializeField]
        [Output(TT.OUT_CURRENT_VAL)]
        private Vector2 m_currentValue;

        protected override GizmoHelper.PartType PartType
        {
            get
            {
                return GizmoHelper.PartType.Discovery;
            }
        }

        internal override void InvokeProcess()
        {
            base.InvokeProcess();
            if (m_source != null)
            {
                m_currentValue = m_source.transform.rotation.eulerAngles;
            }
            SendCommandSignal();
        }
        


    }
}
