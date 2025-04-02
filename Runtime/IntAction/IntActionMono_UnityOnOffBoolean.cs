using UnityEngine;
using UnityEngine.Events;

namespace Eloi.IntAction
{
    public class IntActionMono_UnityOnOffBoolean : AbstractIntegerListenAndEmitterMono
    {
        public IntActionId m_on = new IntActionId(1);
        public IntActionId m_off = new IntActionId(0);
        public bool m_currentValue;
        public UnityEvent<bool> m_onUpdated;
        public UnityEvent m_onOn;
        public UnityEvent m_onOff;

        public void SetOnOff(bool isOn)
        {
            if (isOn)
            {
                TurnOn();
            }
            else
            {
                TurnOff();
            }
        }

        [ContextMenu("Turn On")]
        public void TurnOn()
        {
            m_currentValue = true;
            m_onOn.Invoke();
            m_onUpdated.Invoke(m_currentValue);
        }
        [ContextMenu("Turn Off")]
        public void TurnOff()
        {
            m_currentValue = false;
            m_onOff.Invoke();
            m_onUpdated.Invoke(m_currentValue);
        }

        [ContextMenu("Switch On Off")]
        public void SwitchOnOff() { 
        
            m_currentValue = !m_currentValue;
            if (m_currentValue)
            {
                m_onOn.Invoke();
            }
            else
            {
                m_onOff.Invoke();
            }
        }



        protected override void ChildrenHandlerForIntegerAction(int integerValue)
        {
            if (m_on.m_intActionValue == integerValue)
            {
                TurnOn();
            }
            else if (m_off.m_intActionValue == integerValue)
            {
                TurnOff();
            }
        }
    }

}