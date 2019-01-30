using UnityEngine;

namespace Anglia.CGTech.CKit.Helper
{
    [ExecuteInEditMode]
    public class HideGizmos : MonoBehaviour
    {
        [SerializeField]
        private bool m_hideGizmos = true;
        private bool lastState;
       
        
        void OnEnable()
        {
            lastState = !m_hideGizmos;
        }

        void OnDisable()
        {
            SetGizmoVisibility(false);
        }

        [ExecuteInEditMode]
        void Update()
        {
            if (lastState != m_hideGizmos)
            {
                SetGizmoVisibility(m_hideGizmos);
            }
        }

        private void SetGizmoVisibility(bool isHidden)
        {
            KitComponent[] bits = GetComponentsInChildren<KitComponent>();
            for (int i = 0; i < bits.Length; i++)
            {
                bits[i].hideGizmos = isHidden;
            }
            lastState = isHidden;
        }
    }


}
