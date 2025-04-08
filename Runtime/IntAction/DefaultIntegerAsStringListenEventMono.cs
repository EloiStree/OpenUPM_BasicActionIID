using UnityEngine.Events;

namespace Eloi.IntAction
{
    public class DefaultIntegerAsStringListenEventMono : AbstractIntegerListenEventMono
    {
        public UnityEvent<string> m_onIntegerActionReceivedAsString = new UnityEvent<string>();
        protected override void ChildrenHandlerForIntegerAction(int integerValue)
        {
            m_onIntegerActionReceivedAsString.Invoke(integerValue.ToString());
        }
    }

}