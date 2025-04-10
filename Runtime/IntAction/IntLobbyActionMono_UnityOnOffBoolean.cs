using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

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
            m_integerToTrigger.m_intActionValue = integerValue;
        }
        public IntLobbyAction_IntToUnityEvent(IntActionId integerValue)
        {
            m_integerToTrigger = integerValue;
        }
        public IntLobbyAction_IntToUnityEvent()
        {
            m_integerToTrigger.m_intActionValue = 123456;
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

    [System.Serializable]
    public class IntLobbyAction_UnityOnOffBoolean: I_IntegerListenAndEmitter
    {

        public bool m_isActive = true;
        public IntActionId m_on = new IntActionId(1);
        public IntActionId m_off = new IntActionId(0);
        public bool m_currentValue;
        public UnityEvent<bool> m_onUpdated;
        public UnityEvent m_onOn;
        public UnityEvent m_onOff;

        public IntLobbyAction_UnityOnOffBoolean(int on, int off)
        {
            m_on.m_intActionValue = on;
            m_off.m_intActionValue = off;
        }
        public IntLobbyAction_UnityOnOffBoolean(IntActionId on, IntActionId off)
        {
            m_on = on;
            m_off = off;
        }
        public IntLobbyAction_UnityOnOffBoolean()
        {
            m_on.m_intActionValue = 1;
            m_off.m_intActionValue = 0;
        }


        public void SetOnOffAndPushInteger(bool isOn) => SetOnOff(isOn, true);


        public void SetOnOff(bool isOn, bool pushInteger = false)
        {
            if (isOn)
            {
                TurnOn(pushInteger);
            }
            else
            {
                TurnOff(pushInteger);
            }

        }

       

        [ContextMenu("Turn On and send integer")]
        public void TurnOnAndPushInteger() => TurnOn(true);

        [ContextMenu("Turn Off and send integer")]

        public void TurnOffAndPushInteger() => TurnOff(true);
        [ContextMenu("Turn Off and send integer")]

        public void SwitchOnOffAndPushInteger() => SwitchOnOff(true);


        [ContextMenu("Turn On and dont send integer")]
        public void TurnOnWithoutPushInteger() => TurnOn(false);

        [ContextMenu("Turn Off and dont send integer")]

        public void TurnOffWithoutPushInteger() => TurnOff(false);

        [ContextMenu("Turn Off and dont send integer")]

        public void SwitchOnOff() => SwitchOnOff(false);

        void TurnOn(bool pushInteger)
        {
            m_currentValue = true;
            m_onOn.Invoke();
            m_onUpdated.Invoke(m_currentValue);
            if (pushInteger)
            {
                PushStateAsInteger();
            }
        }
        void TurnOff(bool pushInteger)
        {
            m_currentValue = false;
            m_onOff.Invoke();
            m_onUpdated.Invoke(m_currentValue);
            if (pushInteger)
            {
                PushStateAsInteger();
            }
        }

        [ContextMenu("Switch On Off")]
        void SwitchOnOff(bool pushInteger)
        {

            m_currentValue = !m_currentValue;
            if (m_currentValue)
            {
                m_onOn.Invoke();
            }
            else
            {
                m_onOff.Invoke();
            }
            if (pushInteger)
            {
                PushStateAsInteger();
            }
        }

        public Action<int> m_onRequestToSendInteger;
        public void AddRequestToSendInteger(Action<int> action)
        {
            m_onRequestToSendInteger += action;
        }
        public void RemoveRequestToSendInteger(Action<int> action)
        {
            m_onRequestToSendInteger -= action;
        }

        private void PushStateAsInteger()
        {
            if (!m_isActive)
            {
                return;
            }
            m_onRequestToSendInteger?.Invoke(m_currentValue ? m_on.m_intActionValue : m_off.m_intActionValue);
        }

        public void HandleIntegerAction(int integerValue)
        {
            if (!m_isActive)
            {
                return;
            }
            if (m_on.m_intActionValue == integerValue)
            {
                TurnOn(false);
            }
            else if (m_off.m_intActionValue == integerValue)
            {
                TurnOff(false);
            }
        }

        public void AddEmissionListener(Action<int> listener)
        {
            m_onRequestToSendInteger += listener;
        }

        public void RemoveEmissionListener(Action<int> listener)
        {
            m_onRequestToSendInteger -= listener;
        }

        public bool GetCurrentValue()
        {
            return m_currentValue;
        }
    }
    public class IntLobbyActionMono_UnityOnOffBoolean : AbstractIntegerListenAndEmitterMono
    {
        public IntActionId m_on = new IntActionId(1);
        public IntActionId m_off = new IntActionId(0);
        public bool m_currentValue;
        public UnityEvent<bool> m_onUpdated;
        public UnityEvent m_onOn;
        public UnityEvent m_onOff;


        public void SetOnOffAndPushInteger(bool isOn) =>SetOnOff(isOn, true);
        

        public void SetOnOff(bool isOn, bool pushInteger = false)
        {
            if (isOn)
            {
                TurnOn(pushInteger);
            }
            else
            {
                TurnOff(pushInteger);
            }

        }


        [ContextMenu("Turn On and send integer")]
        public void TurnOnAndPushInteger() => TurnOn(true);

        [ContextMenu("Turn Off and send integer")]

        public void TurnOffAndPushInteger() => TurnOff(true);
        [ContextMenu("Turn Off and send integer")]

        public void SwitchOnOffAndPushInteger() => SwitchOnOff(true);


        [ContextMenu("Turn On and dont send integer")]
        public void TurnOn() => TurnOn(false);

        [ContextMenu("Turn Off and dont send integer")]

        public void TurnOff() => TurnOff(false);

        [ContextMenu("Turn Off and dont send integer")]

        public void SwitchOnOff() => SwitchOnOff(false);

        void TurnOn(bool pushInteger )
        {
            m_currentValue = true;
            m_onOn.Invoke();
            m_onUpdated.Invoke(m_currentValue);
            if (pushInteger)
            {
                PushStateAsInteger();
            }
        }
         void TurnOff(bool pushInteger )
        {
            m_currentValue = false;
            m_onOff.Invoke();
            m_onUpdated.Invoke(m_currentValue);
            if (pushInteger)
            {
                PushStateAsInteger();
            }
        }

        [ContextMenu("Switch On Off")]
         void SwitchOnOff(bool pushInteger) { 
        
            m_currentValue = !m_currentValue;
            if (m_currentValue)
            {
                m_onOn.Invoke();
            }
            else
            {
                m_onOff.Invoke();
            }
            if (pushInteger)
            {
                PushStateAsInteger();
            }
        }

        private void PushStateAsInteger()
        {
            SendInteger(m_currentValue ? m_on.m_intActionValue : m_off.m_intActionValue);
        }

        protected override void ChildrenHandlerForIntegerAction(int integerValue)
        {
            if (m_on.m_intActionValue == integerValue)
            {
                TurnOn(false);
            }
            else if (m_off.m_intActionValue == integerValue)
            {
                TurnOff(false);
            }
        }
    }

}