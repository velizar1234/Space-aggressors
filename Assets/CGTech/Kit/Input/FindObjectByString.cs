using Anglia.CGTech.CKit.Data;
using Anglia.CGTech.CKit.Helper;
using UnityEngine;

namespace Anglia.CGTech.CKit.Input
{
    [AddComponentMenu(MN.FIND_OBJECT)]
    [Summary(HD.FN_FIND_OBJ_WNAME)]
    public class FindObjectByString : FunctionKitComponent
    {
        [SerializeField]
        [Input(TT.ST_STR_NAME)]
        private StringValue m_name;
        [SerializeField]
        [Input(Required.Optional, TT.IN_GOS_ROOT)]
        private GameObjectValue m_searchRoot;

        [Setting(TT.MODE_STR)]
        [SerializeField]
        private GameObjectKeyString m_mode = GameObjectKeyString.Name;

        [Output(TT.OUT_CURRENT_VAL)]
        [SerializeField]
        private GameObject m_currentValue;


        internal override void InvokeProcess()
        {
            base.InvokeProcess();

            string name = "Game Object";
            if (m_name != null)
            {
                name = m_name.Fetch();
            }

            if (m_searchRoot != null )
            {
                GameObject rootObj = m_searchRoot.Fetch();
                
                if (rootObj != null)
                {
                    bool found = false;
                    Transform[] candidates = rootObj.GetComponentsInChildren<Transform>();
                    for (int i = 0; i < candidates.Length; i++)
                    {
                        switch (m_mode)
                        {
                            case GameObjectKeyString.Name:
                                if (candidates[i].gameObject.name == name)
                                {
                                    m_currentValue = candidates[i].gameObject;
                                    found = true; 
                                }
                                break;
                            case GameObjectKeyString.Tag:
                                if (candidates[i].gameObject.tag == name)
                                {
                                    m_currentValue = candidates[i].gameObject;
                                    found = true;
                                }
                                break;
                        }
                        if (found)
                            break;
                    }
                }
            }
            else
                switch (m_mode)
                {
                    case GameObjectKeyString.Name:
                        m_currentValue = GameObject.Find(name);
                        break;
                    case GameObjectKeyString.Tag:
                        m_currentValue = GameObject.FindGameObjectWithTag(name);
                        break;
                }
            SendCommandSignal();
        }


        //public override GameObject Fetch(bool force = false)
        //{
        //    if (!m_calculatedThisFrame)
        //    {
        //        m_calculatedThisFrame = true;

        //        if (m_searchRoot != null)
        //        {
        //            GameObject rootObj = m_searchRoot.Fetch();
        //            if (rootObj != null)
        //            {
        //                Transform[] candidates = rootObj.GetComponentsInChildren<Transform>();
        //                for (int i = 0; i < candidates.Length; i++)
        //                {
        //                    if (candidates[i].gameObject.name == m_name)
        //                    {
        //                        m_currentValue = candidates[i].gameObject;
        //                        break;
        //                    }
        //                }
        //            }

        //        }
        //        else if (m_currentValue == null || m_currentValue.name != m_name)
        //        {
        //            m_currentValue = GameObject.Find(m_name);

        //        }

        //    }
        //    return m_currentValue;
        //}
        protected override GizmoHelper.PartType PartType
        {
            get
            {
                return GizmoHelper.PartType.Discovery;
            }
        }



    }
}