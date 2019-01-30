using Anglia.CGTech.CKit.Data;
using Anglia.CGTech.CKit.Helper;
using UnityEngine;

namespace Anglia.CGTech.CKit.Output
{
    [AddComponentMenu(MN.FN_CREATE_INSTANCE)]
    [Summary(HD.EFF_CREATE)]
    public class CreateInstance : FunctionKitComponent
    {
//pwdCS0219
        [SerializeField]
        [Prefab(TT.IN_PREFAB)]
        private GameObject m_prefab;

        [SerializeField]
        [Input(TT.IN_VEC_LOC)]
        private VectorValue m_location;

        [SerializeField]
        [Input(TT.IN_ACT_BOOL)]
        private BooleanValue m_enabled;

        [SerializeField]
        private bool lastTriggerValue = false;

        [SerializeField]
        [Output(TT.OUT_CURRENT_VAL)]
        private GameObject m_currentValue;
//pwrCS0219

        protected override GizmoHelper.PartType PartType
        {
            get
            {
                return GizmoHelper.PartType.Effect;
            }
        }

        internal override void InvokeProcess()
        {
            base.InvokeProcess();

            bool currentTriggerValue = true;
            if (m_enabled != null)
            {
                currentTriggerValue = m_enabled.Fetch();
            }

            if (m_prefab != null && currentTriggerValue)
            {
                Vector3 location;
                if (m_location == null)
                {
                    location = transform.position;
                }
                else
                {
                    location = new Vector3(m_location.Fetch().x, m_location.Fetch().y, 0);
                }

                m_currentValue = Instantiate(m_prefab, location, Quaternion.identity);
                m_currentValue.name = m_prefab.name;
                lastTriggerValue = currentTriggerValue;
            }
            SendCommandSignal();
        }

    }

}