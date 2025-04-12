using UnityEngine.Events;

namespace Eloi.IntAction
{
    public class DefaultIntegerListenAndEmitterEventMono : DefaultIntegerEmitterEventMono, I_IntActionListener
    {
        public UnityEvent<int> m_onIntegerActionReceived;
        public int m_lastReceived;

        public void HandleIntegerAction(int integerValue)
        {
            m_onIntegerActionReceived.Invoke(integerValue);
            m_lastReceived = integerValue;
            ChildrenHandlerForIntegerAction(integerValue);
        }

        virtual protected void ChildrenHandlerForIntegerAction(int integerValue)
        {
        }
    }

}