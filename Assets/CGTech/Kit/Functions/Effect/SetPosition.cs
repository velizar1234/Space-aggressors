using Anglia.CGTech.CKit.Data;
using Anglia.CGTech.CKit.Helper;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Anglia.CGTech.CKit.Effect
{
    [AddComponentMenu(MN.SET_POSITION)]
    [Summary(HD.EF_SET_POS)]
    public class SetPosition : FunctionKitComponent
    {

        [SerializeField]
        [Input(TT.IN_VEC)]
        private VectorValue m_targetPosition = null;
        [SerializeField]
        [Affects(TT.IN_GOB_AFF)]
        private GameObjectValue m_ObjectToPlace = null;
        [SerializeField]
        [Input(TT.IN_ACT_BOOL)]
        private BooleanValue m_isActive = null;

        internal override void InvokeProcess()
        {
            base.InvokeProcess();

            if (m_ObjectToPlace != null && m_ObjectToPlace.Fetch() !=null && m_targetPosition != null)
            {
                if (m_isActive == null || m_isActive.Fetch())
                {
                    GameObject target = m_ObjectToPlace.Fetch();
                    Rigidbody2D rb2D = target.GetComponent<Rigidbody2D>();
                    if (rb2D != null)
                    {
                        //rb2D.Sleep();
                    }
                    target.transform.position = m_targetPosition.Fetch();
                    if (rb2D != null)
                    {
                        //rb2D.WakeUp();
                    }
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

