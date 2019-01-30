using Anglia.CGTech.CKit.Data;
using Anglia.CGTech.CKit.Helper;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Anglia.CGTech.CKit.Output
{
    [AddComponentMenu(MN.FN_DESTROY)]
    [Summary(HD.DESTROY)]
    public class DestroyGameObject : FunctionKitComponent
    {

        [SerializeField]
        [Input(TT.TGT_GOS)]
        private GameObjectValue m_ObjectToDestroy;
        [SerializeField]
        [Range(0.001f, 100f)]
        [Setting(TT.ST_DELAY)]
        private float m_delay = 1f / 30f;
        [Setting]
        [SerializeField]
        private bool destroyRoot;
        [Ignore]
        GameObject gob = null;

        internal override void InvokeProcess()
        {
            base.InvokeProcess();

            if (m_ObjectToDestroy != null)
            {

                gob = m_ObjectToDestroy.Fetch();
                if (destroyRoot)
                {
                    gob = gob.transform.root.gameObject;
                }
                if (gob != null)
                {
                    if (Application.isPlaying)
                        Destroy(gob, m_delay);
                }

            }
            SendCommandSignal();
        }


        protected override GizmoHelper.PartType PartType
        {
            get
            {
                return GizmoHelper.PartType.Effect;
            }
        }


    }
}
