using System;

namespace Anglia.CGTech.CKit.Helper
{
    public class TriggerArgs : EventArgs
    {
        public enum CommandType
        {
            Undefined = 0,
            Invocation,
            Reset,
            FunctionCall,
        }

        /// <summary>
        /// Whether the triggered object should be forced to recalculate.
        /// </summary>
        public bool isForced = false;

        public CommandType commandType = CommandType.Invocation;
    }
}