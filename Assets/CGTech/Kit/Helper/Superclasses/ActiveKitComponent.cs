using System;
using System.Reflection;
using UnityEngine;

namespace Anglia.CGTech.CKit.Helper
{
    /// <summary>
    /// Active Kit Component (superclass) for representing timing sensitive and trigger operations.
    /// </summary>
    public class ActiveKitComponent : KitComponent
    {

        #region Command Event Code

        public delegate void NextProcess(bool isForced = false);

        public event EventHandler<TriggerArgs> OnCommandSignal;

        protected void SendCommandSignal(bool isForced = false, TriggerArgs.CommandType type = TriggerArgs.CommandType.Invocation)
        {
            if (type == TriggerArgs.CommandType.Invocation)
                Activity = GizmoHelper.ActivityPeakValue;
            if (OnCommandSignal != null)
            {
                if (OnCommandSignal.GetInvocationList().Length > 1)
                {
                    Debug.LogWarningFormat("Too many functions ({0}) triggered by {1} event. Sequence is unpredictable above 1.", OnCommandSignal.GetInvocationList().Length, gameObject.name);
                }
                TriggerArgs ta = new TriggerArgs();
                ta.isForced = isForced;
                ta.commandType = type;
                OnCommandSignal(this, ta);
            }
        }




        protected override void OnEnable()
        {
            base.OnEnable();
            AttachTriggerEvents(true);

        }

        protected override void OnDisable()
        {
            base.OnEnable();
            AttachTriggerEvents(false);
        }

        protected virtual void OnDestroy()
        {
            AttachTriggerEvents(false);
        }

        private void AttachTriggerEvents(bool attach)
        {
            FieldInfo[] fields = this.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
            for (int i = 0; i < fields.Length; i++)
            {
                FieldInfo currentField = fields[i];
                CKitFieldAttribute attrib = Attribute.GetCustomAttribute(currentField, typeof(CKitFieldAttribute)) as CKitFieldAttribute;

                if (attrib is CommandAttribute)
                {
                    if (!currentField.FieldType.IsArray)
                    {
                        object ob = currentField.GetValue(this);
                        if (ob is ActiveKitComponent)
                        {
                            ActiveKitComponent commandSignal = (ActiveKitComponent)ob;
                            if (attach)
                                commandSignal.OnCommandSignal += HandleOnCommandSignal;
                            else
                                commandSignal.OnCommandSignal -= HandleOnCommandSignal;
                        }
                    }
                    else
                    {
                        object[] sources = (object[]) currentField.GetValue(this);
                        for (int j = 0; j<sources.Length;j++)
                        {
                            object ob = sources[j];
                            if (ob is ActiveKitComponent)
                            {
                                ActiveKitComponent commandSignal = (ActiveKitComponent)ob;
                                if (attach)
                                    commandSignal.OnCommandSignal += HandleOnCommandSignal;
                                else
                                    commandSignal.OnCommandSignal -= HandleOnCommandSignal;
                            }
                        }
                    }
                }
            }
        }

        internal virtual void InvokeProcess()
        {
            Activity = GizmoHelper.ActivityPeakValue;
        }

        internal virtual void ResetProcess()
        {
        }

        internal virtual void CallProcess()
        { }

        private void HandleOnCommandSignal(object sender, TriggerArgs e)
        {
            //Debug.Log("Event received Forced = " + e.isForced.ToString());
            switch (e.commandType)
            {
                case TriggerArgs.CommandType.FunctionCall:
                    CallProcess();
                    break;
                case TriggerArgs.CommandType.Invocation:
                    InvokeProcess();
                    break;
                case TriggerArgs.CommandType.Reset:
                    ResetProcess();
                    break;
            }
            //SendCommandSignal(e.isForced);
        }

        #endregion

        protected override GizmoHelper.PartType PartType
        {
            get
            {
                return GizmoHelper.PartType.Undefined;
            }
        }
    }
}