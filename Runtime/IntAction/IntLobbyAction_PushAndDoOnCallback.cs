using System;
using UnityEngine;
using UnityEngine.Events;

namespace Eloi.IntAction
{
    /// <summary>
    /// I am a class that allows to send integer to lobby and only do the action when the integer is coming back
    /// </summary>
    [System.Serializable]
    public class IntLobbyAction_PushAndDoOnCallback :  I_IntegerListenAndEmitter, I_ContainsOneIntegerActionId, I_HasSendIntegerHandler
    {
        [SerializeField] IntActionId m_actionAsInteger= new IntActionId(1);
        public UnityEvent m_onCallbackTriggered;
        public UnityEvent m_onPushTriggered;
        
        public DebugValue m_dateForDebug = new DebugValue();
        [System.Serializable]
        public class DebugValue {

            public DateTime m_sent;
            public DateTime m_received;
            public string m_whenSentLastTime;
            public string m_whenReceivedLastTime;
            public int m_millisecondsBetween;
            public bool m_lessThanOneSecond;

            public void SetReceived(DateTime dateTime)
            {
                m_received = dateTime;
                m_whenReceivedLastTime = m_received.ToString("hh:mm:ss.fff");
                m_millisecondsBetween = (int)(m_received - m_sent).TotalMilliseconds;
                m_lessThanOneSecond = m_millisecondsBetween < 1000;
            }
            public void SetSent(DateTime dateTime)
            {
                m_sent = dateTime;
                m_whenSentLastTime = m_sent.ToString("hh:mm:ss.fff");
            }
        }



        private void NotifyIntegerPushed(int integer)
        {
            if ( integer == m_actionAsInteger.Value)
            {
                m_onPushTriggered?.Invoke();
                m_dateForDebug.SetSent(DateTime.Now);
            }
        }


        public void SendInteger(int integerValue)
        {
            if (integerValue == m_actionAsInteger.Value)
            {
                m_onPushTriggered.Invoke();
                m_onEmissionIsRequested?.Invoke(integerValue);
            }
        }


        public void GetIntActionId(out IntActionId integerActionId)
        {
            integerActionId = m_actionAsInteger;
        }


        public void SetIntActionId(IntActionId integerActionId)
        {
            m_actionAsInteger = integerActionId;
        }

        public void SetIntActionId(int integerActionId)
        {
            m_actionAsInteger.Value = integerActionId;

        }

        public void HandleIntegerAction(int integerValue)
        {
            if (m_actionAsInteger.Value == integerValue)
            {
                m_onCallbackTriggered?.Invoke();
                m_dateForDebug.SetReceived(DateTime.Now);
            }
        }

         Action<int> m_onEmissionIsRequested;

        public void AddEmissionListener(Action<int> listener)
        {
            m_onEmissionIsRequested += listener;
        }

        public void RemoveEmissionListener(Action<int> listener)
        {
            m_onEmissionIsRequested -= listener;
        }

        public void PushTheWaitingInteger()
        {
            SendInteger(m_actionAsInteger.Value);
        }
    }
}