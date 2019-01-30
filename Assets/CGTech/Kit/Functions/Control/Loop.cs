using Anglia.CGTech.CKit.Data;
using Anglia.CGTech.CKit.Helper;
using UnityEngine;

namespace Anglia.CGTech.CKit.Control
{
    [AddComponentMenu(MN.Loop)]
    [Summary(HD.LOOP)]
    public class Loop : FunctionKitComponent
    {
//pwdCS0219

        [SerializeField]
        [Input(TT.IN_INT_FROM)]
        private IntegerValue m_fromValue;
        [SerializeField]
        [Input(TT.IN_INT_TO)]
        private IntegerValue m_untilValue;
        [SerializeField]
        [Command]
        private ActiveKitComponent m_incrementNow;
        [SerializeField]
        [Input(TT.IN_RST_BOOL)]
        private BooleanValue m_reset;

        [Affects(TT.TODO)]
        [SerializeField]
        private FunctionKitComponent m_repeatFunction;

        [Output(TT.TODO)]
        [SerializeField]
        int m_Index = 0;
//pwrCS0219 
        internal override void InvokeProcess()
        {
            base.InvokeProcess();
            int from = 0, to = 0;
            if (m_fromValue != null && m_untilValue != null)
            {
                from = m_fromValue.Fetch();
                to = m_untilValue.Fetch();
            }
            for(m_Index = from; m_Index < to; m_Index++)
            {
                if (m_repeatFunction != null)
                {
                    //m_repeatFunction.ResetProcess();
                    m_repeatFunction.InvokeProcess();
                    Debug.LogFormat("Looping {0}", m_Index);
                }
            }
            SendCommandSignal();
        }

        //private int delay = 0;

        //public override int Fetch(bool force = false)
        //{


        //    if (!m_calculatedThisFrame)
        //    {

        //        m_changeTrigger = false;
        //        m_calculatedThisFrame = true;
        //        int fromValue=0, toValue=0;
        //        if (m_fromValue != null)
        //            fromValue = m_fromValue.Fetch();
        //        if (m_untilValue != null)
        //            toValue = m_untilValue.Fetch();

        //        if (m_fromValue != null && m_untilValue != null )
        //        {
        //            if (m_currentValue == int.MinValue ||
        //                (m_reset != null && m_reset.Fetch()))
        //            {
        //                m_currentValue = fromValue;
        //                m_changeTrigger = true;
        //            }
        //            else if (m_incrementNow == null || m_incrementNow.Fetch())
        //            {
        //                if ((m_currentValue + 1) < toValue)
        //                {
        //                    m_currentValue++;
        //                    m_changeTrigger = true;
        //                }

        //            }
        //        }
        //    }
        //    return m_currentValue;
        //}
        protected override GizmoHelper.PartType PartType
        {
            get
            {
                return GizmoHelper.PartType.ProcessActive;
            }
        }
        
    }
}