using Anglia.CGTech.CKit.Data;
using Anglia.CGTech.CKit.Helper;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

namespace Anglia.CGTech.CKit.Output
{
    [AddComponentMenu("Construction Kit/Effect/Load Scene")]
    [Summary(HD.EF_LOAD_SCENE)]
    public class LoadScene : KitComponent
    {
        #region Inspector Elements
        [SerializeField]
        [Setting(TT.IN_STR_SCENE)]
        private string m_sceneName;
        [SerializeField]
        [Setting(TT.IN_BOOL_ADDITIVE)]
        private bool m_loadAdditive = false;
        [SerializeField]
        [Input(TT.IN_TRG_BOOL)]
        private BooleanValue m_source;
        #endregion
        private bool m_isDone = false;

        protected override GizmoHelper.PartType PartType
        {
            get
            {
                return GizmoHelper.PartType.Effect;
            }
        }

        protected override void Update()
        {
            base.Update();
            if (m_source == null || m_source.Fetch())
            {
                if (!m_isDone)
                {
                    m_isDone = true;
                    if (m_loadAdditive)
                        SceneManager.LoadScene(m_sceneName, LoadSceneMode.Additive);
                    else
                        SceneManager.LoadScene(m_sceneName, LoadSceneMode.Single);
                }
            }
        }

    }
}
