using System;
using UnityEngine;
using UnityEngine.Events;

namespace Eloi.IntAction
{

        /// <summary>
        /// I am class that ease the use of a toggle value in a lobby game.
        /// Give me an integer and I will toggle the value if the integer is the one I expect
        /// When Changing of value state I emit the integer value to be handled by the lobby manager
        /// </summary>
        [System.Serializable]
    public class IntLobbyAction_Toggle: I_IntegerListenAndEmitter, I_HasSendIntegerHandler
    {
        [Header("Toggle")]
        public IntActionId m_onIntegerId = new IntActionId(1);
        public IntActionId m_offIntegerId = new IntActionId(0);
        public bool m_currentValue;
        [Header("Event")]
        public UnityEvent<bool> m_onValueUpdated;
        public UnityEvent<bool> m_onValueChanged;
        public UnityEvent m_onOnChanged;
        public UnityEvent m_onOffChanged;

        public IntLobbyAction_Toggle(int on, int off)
        {
            m_onIntegerId = on;
            m_offIntegerId= off;
        }
        public IntLobbyAction_Toggle(IntActionId on, IntActionId off)
        {
            m_onIntegerId = on;
            m_offIntegerId = off;
        }
        public IntLobbyAction_Toggle()
        {
            m_onIntegerId= 1;
            m_offIntegerId = 0;
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

        public void SwitchOnOffWithoutPushInteger() => SwitchOnOff(false);

        void TurnOn(bool pushInteger)
        {

            bool oldValue = m_currentValue;
            m_currentValue = true;
            m_onOnChanged.Invoke();
            m_onValueUpdated.Invoke(m_currentValue);
            if (oldValue != m_currentValue)
            {
                m_onValueChanged.Invoke(m_currentValue);
            }
            if (pushInteger)
            {
                PushStateAsInteger();
            }
        }


        void TurnOff(bool pushInteger)
        {
            bool oldValue = m_currentValue;
            m_currentValue = false;
            m_onOffChanged.Invoke();
            m_onValueUpdated.Invoke(m_currentValue);

            if (oldValue != m_currentValue)
            {
                m_onValueChanged.Invoke(m_currentValue);
            }
            if (pushInteger)
            {
                PushStateAsInteger();
            }
        }

        [ContextMenu("Switch On Off")]
        void SwitchOnOff(bool pushInteger)
        {
            m_currentValue = !m_currentValue;
            m_onValueUpdated.Invoke(m_currentValue);
            if (m_currentValue)
            {
                m_onOnChanged.Invoke();
            }
            else
            {
                m_onOffChanged.Invoke();
            }
            m_onValueChanged.Invoke(m_currentValue);
            if (pushInteger)
            {
                PushStateAsInteger();
            }
        }

        private Action<int> m_onRequestToSendInteger;
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
            SendInteger(m_currentValue ? m_onIntegerId.Value : m_offIntegerId.Value);
        }
        public void SendInteger(int integerValue)
        {
            m_onRequestToSendInteger?.Invoke(integerValue);
        }

        public void HandleIntegerAction(int integerValue)
        {
            
            if (m_onIntegerId.Value == integerValue)
            {
                TurnOn(false);
            }
            else if (m_offIntegerId.Value == integerValue)
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

        public void SetIntegerIdWhenOn(int integerValue)
        {
            m_onIntegerId.Value = integerValue;   
        }
        public void SetIntegerIdWhenOff(int integerValue)
        {
            m_offIntegerId.Value = integerValue;
        }
    }
}