using UnityEngine;
using UnityEngine.Events;

namespace Eloi.IntAction
{
    public class DefaultIntegerEmitterEventMono: MonoBehaviour, I_IntegerEmitter
    {
        public UnityEvent<int> m_onIntegerActionEmitted;
        public int m_lastPushed;

       
        public void AddEmissionListener(UnityAction<int> listener)
        {
            m_onIntegerActionEmitted.AddListener(listener);
        }
        public void RemoveEmissionListener(UnityAction<int> listener)
        {
            m_onIntegerActionEmitted.RemoveListener(listener);
        }
        public void SendInteger(int integer)
        {
            m_onIntegerActionEmitted.Invoke(integer);
            m_lastPushed = integer;
        }
        public void SendInteger(IntActionId integer)
        {
            m_onIntegerActionEmitted.Invoke(integer.GetIntegerValue());
            m_lastPushed = integer.GetIntegerValue();
        }
    }

}