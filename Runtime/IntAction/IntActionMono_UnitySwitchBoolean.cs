﻿using UnityEngine;
using UnityEngine.Events;

namespace Eloi.IntAction
{
    public class IntActionMono_UnitySwitchBoolean : MonoBehaviour, I_IntActionBroadcastListener
    {
        public IntActionId m_integerSwitch = new IntActionId(308);
        public IntActionId m_integerOff = new IntActionId(208);
        public IntActionId m_integerOn = new IntActionId(108);
        public bool m_currentValue;

        public UnityEvent<bool> m_onSwitchValue;
        public UnityEvent m_onSwitchToTrue;
        public UnityEvent m_onSwitchToFalse;

        public int m_lastReceivedValue;
      

        public void HandleBroadcastedInteger(int integerValue)
        {
            m_lastReceivedValue = integerValue;
            if (m_integerOff.m_intActionValue == integerValue)
            {
                TurnOff();
            }
            else if (m_integerOn.m_intActionValue == integerValue)
            {
                TurnOn();
            }
            else if (m_integerSwitch.m_intActionValue == integerValue)
            {
                SwitchValueOnOff();
            }
        }

        [ContextMenu("Switch on off")]
        public void SwitchValueOnOff()
        {
            m_currentValue = !m_currentValue;
            m_onSwitchValue.Invoke(m_currentValue);
            if (m_currentValue)
            {
                m_onSwitchToTrue.Invoke();
            }
            else
            {
                m_onSwitchToFalse.Invoke();
            }
        }

        [ContextMenu("Turn on")]
        public void TurnOn()
        {
            m_currentValue = true;
            m_onSwitchValue.Invoke(m_currentValue);
            m_onSwitchToTrue.Invoke();
        }

        [ContextMenu("Turn off")]
        public void TurnOff()
        {
            m_currentValue = false;
            m_onSwitchValue.Invoke(m_currentValue);
            m_onSwitchToFalse.Invoke();
        }
    }

}