using System;
using Unity.VisualScripting.YamlDotNet.Core;
using UnityEngine;
using UnityEngine.Events;

namespace Eloi.IntAction
{
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