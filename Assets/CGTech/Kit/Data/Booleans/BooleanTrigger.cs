using Anglia.CGTech.CKit.Helper;
using UnityEngine;

//Edited by LB
//Date: 15-Feb-2018

namespace Anglia.CGTech.CKit.Data
{
    /// <summary>
    /// The Boolean Trigger component filters a boolean (true/false) value.  
    /// Depending on the mode,  the output will follow (Continuous), be opposite (Inverted) or be true when the value changes.
    /// </summary>
    [AddComponentMenu("Construction Kit/Convert/Boolean to Trigger")]
    [Summary(HD.BOOL_2_TRG)]
    public class BooleanTrigger : CommandSignal
    {

        [SerializeField]
        [Input(TT.IN_BOOL)]
        private BooleanValue m_source;
        [SerializeField]
        [Setting(TT.BOOL_MODE+TT.NEWLINE+TT.BOOL_MODE_1+TT.BOOL_MODE_2+TT.BOOL_MODE_3+TT.BOOL_MODE_4+TT.BOOL_MODE_5)]
        private BooleanBehaviour m_mode = BooleanBehaviour.OnTrue;
        [Ignore]
        private bool lastValue = false;

        protected override void Update()
        {
            base.Update();
            SendCommandSignal(false, TriggerArgs.CommandType.Reset);
            bool sendCommand = false;
            bool newValue = false; 
                if (m_source != null)
                {
					newValue = m_source.Fetch();
                }
                else
                {
                    Debug.LogWarningFormat(WM.IN_NULL, this.GetType().Name.ToString(), gameObject.name);
                }

                switch (m_mode)
                {
                    case BooleanBehaviour.Inverted:
					sendCommand = !newValue;
                        break;
                    case BooleanBehaviour.Continuous:
					sendCommand = newValue;
                        break;
                    case BooleanBehaviour.Once:
					sendCommand = lastValue || newValue;
                        break;
                    case BooleanBehaviour.OnTrue:
					sendCommand = lastValue == false && newValue == true && lastValue != newValue;
                        break;
                    case BooleanBehaviour.OnFalse:
					sendCommand = lastValue == true && newValue == false && lastValue != newValue;
                        break;

                    default:
                        Debug.LogWarningFormat(WM.BOOL_MODE_UNSUPPORTED, m_mode.ToString(), gameObject.name);
                        break;

                }
            
			lastValue = newValue;
            if (sendCommand)
                SendCommandSignal(false, TriggerArgs.CommandType.Invocation);
        }

        #region HFC
        protected override GizmoHelper.PartType PartType
        {
            get
            {
                return GizmoHelper.PartType.Storage;
            }
        }

        //protected override void DrawGizmos()
        //{
            
        //    if (m_source != null)
        //    {
        //        GizmoHelper.DrawArrow(m_source.transform.position, transform.position, GizmoHelper.KitType.Boolean);
        //    }

        //    //Gizmos.DrawIcon(transform.position, "FloatingPointStore.png", true);
        //}
        #endregion
    }
}
