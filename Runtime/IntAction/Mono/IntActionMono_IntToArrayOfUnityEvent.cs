using UnityEngine;
using UnityEngine.Events;

namespace Eloi.IntAction
{
    public class IntActionMono_IntToArrayOfUnityEvent : DefaultIntegerListenEventMono
    {
        public IntToSingleUnityEvent[] m_data = new IntToSingleUnityEvent[] {
            new IntToSingleUnityEvent(){m_triggerValue = 700, m_onTriggered = new UnityEvent()},
          };

        protected override void ChildrenHandlerForIntegerAction(int integerValue)
        {

            for (int i = 0; i < m_data.Length; i++)
            {
                if (m_data[i] != null &&
                    m_data[i].m_triggerValue == integerValue)
                {
                    m_data[i].m_onTriggered.Invoke();
                }
            }
        }
    }
    [System.Serializable]
    public class IntToSingleUnityEvent
    {
        public IntActionId m_triggerValue = 0;
        public UnityEvent m_onTriggered = new UnityEvent();
    }

}