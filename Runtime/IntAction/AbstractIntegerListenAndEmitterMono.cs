using UnityEngine;
using UnityEngine.Events;

namespace Eloi.IntAction
{
    public abstract class AbstractIntegerListenAndEmitterMono : DefaultIntegerEmitterEventMono, I_IntActionListener
    {
        public void HandleIntegerAction(int integerValue)
        {
            ChildrenHandlerForIntegerAction(integerValue);
        }
        protected abstract void ChildrenHandlerForIntegerAction(int integerValue);

    }

    public abstract class AbstractIntegerListenEventMono : MonoBehaviour, I_IntActionListener
    {
        public UnityEvent<int> m_onIntegerActionReceived;
        public int m_lastReceived;

        public void HandleIntegerAction(int integerValue)
        {
            m_onIntegerActionReceived.Invoke(integerValue);
            m_lastReceived = integerValue;
            ChildrenHandlerForIntegerAction(integerValue);
        }
        protected abstract void ChildrenHandlerForIntegerAction(int integerValue);
    }

}