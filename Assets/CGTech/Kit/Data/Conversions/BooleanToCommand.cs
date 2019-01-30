using Anglia.CGTech.CKit.Data;
using Anglia.CGTech.CKit.Helper;
using UnityEngine;

namespace Anglia.CGTech.CKit.Conversion
{
    /// <summary>
    /// The Boolean Trigger component filters a boolean (true/false) value.  
    /// Depending on the mode,  the output will follow (Continuous), be opposite (Inverted) or be true when the value changes.
    /// </summary>
    [AddComponentMenu(MN.BoolToCommand)]
    [Summary(HD.BOOL_2_SIGNAL)]
    public class BooleanToCommand : CommandSignal
    {
        #region Fields
        
        [Header(CS.INPUTS)]
        [SerializeField]
        [Input(TT.IN_BOOL)]
        private BooleanValue m_source;
        [SerializeField]
        [Setting(TT.BOOL_MODE + TT.BOOL_MODE_1 + TT.BOOL_MODE_2 + TT.BOOL_MODE_3 + TT.BOOL_MODE_4 + TT.BOOL_MODE_5)]
        private BooleanBehaviour m_mode = BooleanBehaviour.OnTrue;
         
        [SerializeField]
        [Output(TT.OUT_CURRENT_VAL)]
        private bool m_currentValue = false;

        private bool currentValue = false;
        private bool lastValue = false;

        #endregion

        protected override void Update()
        {
            base.Update();

   
                if (m_source != null)
                {
                    currentValue = m_source.Fetch();
                }

                switch (m_mode)
                {
                    case BooleanBehaviour.Inverted:
                        m_currentValue = !currentValue;
                        break;
                    case BooleanBehaviour.Continuous:
                        m_currentValue = currentValue;
                        break;
                    case BooleanBehaviour.Once:
                        m_currentValue = m_currentValue || currentValue;
                        break;
                    case BooleanBehaviour.OnTrue:
                        m_currentValue = m_currentValue == false && currentValue == true && lastValue != currentValue;
                        break;
                    case BooleanBehaviour.OnFalse:
                        m_currentValue = m_currentValue == true && currentValue == false && lastValue != currentValue;
                        break;

                    default:
                        Debug.LogWarningFormat("Unexpected Boolean Mode {0} in InitialisationTrigger on {1}", m_mode.ToString(), gameObject.name);
                        break;

                }
            lastValue = currentValue;
            if (m_currentValue)
                SendCommandSignal();
           
        }

        protected override GizmoHelper.PartType PartType
        {
            get
            {
                return GizmoHelper.PartType.Event;
            }
        }

    }
}

