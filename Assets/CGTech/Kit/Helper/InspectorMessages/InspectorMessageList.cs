using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Anglia.CGTech.CKit.Helper.InspectorMessages
{
    public class InspectorMessageList
    {
        private List<InspectorMessage> m_messages = new List<InspectorMessage>();

        public InspectorMessage Display(string message, params object[] values)
        {
            InspectorMessage inspMessage = m_messages.Find(t => t.Message == message);
            if (inspMessage == null)
            {
                inspMessage = new InspectorMessage(message);
                m_messages.Add(inspMessage);
                inspMessage.SetValues(values);
            }
            inspMessage.Enabled = true;
            return inspMessage;
        }

        public void Hide(string message)
        {
            InspectorMessage inspMessage = m_messages.Find(t => t.Message == message);
            if (inspMessage == null)
            {
                Hide(inspMessage);
            }
        }

        public void Hide(InspectorMessage message)
        {
            if (message != null)
                message.Enabled = false;
        }


        public string[] Messages
        {
            get
            {
                string[] result = new string[m_messages.Count(t => t.Enabled)];
                int j = 0;
                for (int i = 0; i < result.Length; i++)
                {
                    if (m_messages[j].Enabled)
                    {
                        result[i] = m_messages[j].DisplayMessage;
                    }
                    j++;
                }
                return result;
            }
        }
    }
}
