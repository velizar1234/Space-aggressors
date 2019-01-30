using Anglia.CGTech.CKit.Data;
using Anglia.CGTech.CKit.Helper;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Anglia.CGTech.CKit.Control
{
    [AddComponentMenu(MN.If)]
    [Summary(HD.IF)]
    public class If : FunctionKitComponent
    {
        [SerializeField]
        [Input(TT.IN_BOOL)]
        private BooleanValue m_sourceCondition;

        [SerializeField]
        [Affects("",typeof(FunctionKitComponent))]
        private FunctionKitComponent m_whenTrue;

        protected override GizmoHelper.PartType PartType
        {
            get
            {
                return GizmoHelper.PartType.Block;
            }
        }

        internal override void InvokeProcess()
        {
            base.InvokeProcess();
            if (m_sourceCondition != null)
            {
                if (m_sourceCondition.Fetch())
                {
                    if (m_whenTrue != null)
                    {
                        m_whenTrue.InvokeProcess();
                    }
                }
                else
                {
                    SendCommandSignal();
                }
            }

        }
    }
}