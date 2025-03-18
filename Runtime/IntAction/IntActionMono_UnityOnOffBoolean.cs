using UnityEngine;
using UnityEngine.Events;

namespace Eloi.IntAction
{
    public class IntActionMono_UnityOnOffBoolean : MonoBehaviour, I_IntActionBroadcastListener
    {
        public IntActionId m_on = new IntActionId(1);
        public IntActionId m_off = new IntActionId(0);
        public bool m_currentValue;
        public UnityEvent<bool> m_onUpdated;
        public UnityEvent m_onOn;
        public UnityEvent m_onOff;
        public void PushIn(int integerValue)
        {
  
            if (m_on.m_intActionValue == integerValue)
            {
                m_currentValue = true;
                m_onOn.Invoke();
                m_onUpdated.Invoke(m_currentValue);
            }
            else if (m_off.m_intActionValue == integerValue)
            {
                m_currentValue = false;
                m_onOff.Invoke();
                m_onUpdated.Invoke(m_currentValue);
            }
        }
    }

}