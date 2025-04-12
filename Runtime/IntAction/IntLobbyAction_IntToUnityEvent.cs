using System;
using UnityEngine.Events;

namespace Eloi.IntAction
{
    [System.Serializable]
    public class IntLobbyAction_IntToUnityEvent: I_IntActionListener
    {

        public bool m_isActive = true;
        public IntActionId m_integerToTrigger= new IntActionId(123);
        public UnityEvent<int> m_onIntegerActionReceived;
        public int m_lastReceived;
        public string m_lastTimeReceived;


        public IntLobbyAction_IntToUnityEvent(int integerValue)
        {
            m_integerToTrigger.Value = integerValue;
        }
        public IntLobbyAction_IntToUnityEvent(IntActionId integerValue)
        {
            m_integerToTrigger = integerValue;
        }
        public IntLobbyAction_IntToUnityEvent()
        {
            m_integerToTrigger.Value = 123456;
        }

        public void HandleIntegerAction(int integerValue)
        {
            if (!m_isActive)
            {
                return;
            }
            if (m_integerToTrigger == integerValue)
            {
                m_onIntegerActionReceived?.Invoke(integerValue);
                m_lastReceived = integerValue;
                m_lastTimeReceived = DateTime.Now.ToString();
            }
        }

        public void InvokeWithCurrentInteger()
        {
            if (!m_isActive)
            {
                return;
            }
            HandleIntegerAction(m_lastReceived);
        }
    }

}