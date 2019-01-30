using Anglia.CGTech.CKit.Data;
using Anglia.CGTech.CKit.Helper;
using UnityEngine;

namespace Anglia.CGTech.CKit.Input
{
    [AddComponentMenu("Construction Kit/Discover/String from Game Object")]
    [Summary(HD.GOB_2_STR)]
    public class ExtractStringFromGameObject : StringValue
    {
    
        [SerializeField]
        [Input(TT.TGT_GOB)]
        private GameObjectValue m_target;
        [SerializeField]
        [Setting(TT.MODE_STR)]
        private GameObjectKeyString m_mode = GameObjectKeyString.Tag;


        protected override GizmoHelper.PartType PartType
        {
            get
            {
                return GizmoHelper.PartType.Discovery;
            }
        }
        protected override void DrawGizmos()
        {
            if (m_target != null)
            {
                GizmoHelper.DrawArrow(m_target.transform.position, transform.position, GizmoHelper.KitType.String);
            }
        }

        public override string Fetch()
        {
            
                m_currentValue = "";
                if (m_target != null)
                {
                    GameObject currentTarget = m_target.Fetch();
                    if (currentTarget != null)
                    {
                        switch (m_mode)
                        {
                            case GameObjectKeyString.Tag:
                                m_currentValue = currentTarget.tag;
                                //Debug.LogFormat("Extracted tag from {0} is {1}", currentTarget.name, m_currentValue);
                                break;
                            case GameObjectKeyString.Name:
                                m_currentValue = currentTarget.name;
                                break;
                            default:
                                m_currentValue = "";
                                Debug.LogWarningFormat(WM.MODE_UNSUPPORTED, m_mode, this.GetType().ToString(), gameObject.name);
                                break;
                        }

                    }
                
            }
            return m_currentValue;
        }
    }
}