using UnityEngine.Events;

namespace Eloi.IntAction
{
    public class DefaultIntegerListenAndEmitterEventMono : AbstractIntegerListenAndEmitterMono, I_IntActionListener
    {
        public UnityEvent<int> m_onIntegerActionReceived;
        public int m_lastReceived;
        protected override void ChildrenHandlerForIntegerAction(int integerValue)
        {
            m_onIntegerActionReceived.Invoke(integerValue);
            m_lastReceived = integerValue;
        }
    }

}