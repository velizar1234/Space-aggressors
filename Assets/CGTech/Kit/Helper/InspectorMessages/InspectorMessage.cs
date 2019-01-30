using System;
using System.Collections.Generic;

namespace Anglia.CGTech.CKit.Helper.InspectorMessages
{
    public class InspectorMessage
    {
        public const float MessageTimeOut = 5;

        public List<string> parameters = new List<string>();

        private string m_message;
        private string m_formattedMessage;
        private DateTime lastPokedAt;

        public InspectorMessage(string message)
        {
            this.m_message = message;
            m_formattedMessage = FormatMessage(message);
            RecordActivity();
        }

        public void SetValues(object[] values)
        {
            parameters.Clear();
            for (int i = 0; i < values.Length; i++)
            {
                parameters.Add(values[i].ToString());
            }
            m_formattedMessage = FormatMessage(m_message);
            RecordActivity();
        }

        private void RecordActivity()
        {
            lastPokedAt = DateTime.Now;
        }

        public string DisplayMessage
        {
            get
            {
                return m_formattedMessage;
            }
        }

        public string Message
        {
            get
            {
                string result = m_message;
                
                return result;
            }
        }

        private string FormatMessage(string result)
        {
            for (int i = 0; i < parameters.Count; i++)
            {
                result = result.Replace("{" + i + "}", parameters[i]);
            }

            return result;
        }

        private bool m_enabled = true;

        public bool Enabled
        {
            get
            {
                if (m_enabled && (DateTime.Now - lastPokedAt).Seconds > MessageTimeOut)
                {
                    m_enabled = false;
                }
                return m_enabled;
            }
            set
            {
                m_enabled = value;
                RecordActivity();
            }
        }
    }
}