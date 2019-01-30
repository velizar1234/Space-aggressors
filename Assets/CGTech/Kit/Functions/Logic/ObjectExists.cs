using Anglia.CGTech.CKit.Data;
using Anglia.CGTech.CKit.Helper;
using UnityEngine;

namespace Anglia.CGTech.CKit.Functions
{
    [AddComponentMenu(MN.ObExists)]
    [Summary(HD.FN_OBJEXIST)]
    public class ObjectExists : BooleanValue
    {
//pwdCS0219        
        [SerializeField]
        [Input(TT.IN_GOS)]
        private GameObjectValue m_source;
        //[SerializeField]
        //[Setting(TT.BOOL_MODE+TT.BOOL_MODE_1+TT.BOOL_MODE_2+TT.BOOL_MODE_3+TT.BOOL_MODE_4+TT.BOOL_MODE_5)]
        //private BooleanBehaviour m_mode = BooleanBehaviour.OnTrue;
        //[Ignore]
        //private bool m_lastValue;
//pwrCS0219

        public override bool Fetch()
        {
            if (!m_calculatedThisFrame)
            {
                m_calculatedThisFrame = true;
                bool newValue = false;
                if (m_source != null)
                {
                    if (m_source.Fetch() != null)
                        newValue = true;
                }
                else
                {
                    newValue = true;
                }

                //switch (m_mode)
                //{
                //    case BooleanBehaviour.Undefined:
                //    case BooleanBehaviour.Continuous:
                        m_currentValue = newValue;
                //        break;
                //    case BooleanBehaviour.OnTrue:
                //        m_currentValue = newValue == true && m_lastValue == false; 
                //        break;
                //    case BooleanBehaviour.OnFalse:
                //        m_currentValue = newValue == false && m_lastValue == true;
                //        break;
                //    case BooleanBehaviour.Once:
                //        m_currentValue = newValue == true || m_lastValue == true;
                //        break;
                //    case BooleanBehaviour.Inverted:
                //        m_currentValue = !newValue;
                //        break;
                //}
                //m_lastValue = m_currentValue || newValue;
            }
            
            return m_currentValue;
        }

        protected override GizmoHelper.PartType PartType
        {
            get
            {
                return GizmoHelper.PartType.ProcessPassive;
            }
        }



    }
}
