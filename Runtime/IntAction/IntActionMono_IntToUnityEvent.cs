using UnityEngine;
using UnityEngine.Events;

namespace Eloi.IntAction
{
    public class IntActionMono_IntToUnityEvent : MonoBehaviour, I_IntActionBroadcastListener
    {
        public IntToEventSet[] m_data = new IntToEventSet[] {
            new IntToEventSet(){m_integer = 700, m_onInvoke = new UnityEvent()},
          };
        public void HandleBroadcastedInteger(int integerValue)
        {
            for (int i = 0; i < m_data.Length; i++)
            {
                if (m_data[i]!=null&&
                    m_data[i].m_integer == integerValue)
                {
                    m_data[i].m_onInvoke.Invoke();
                    return;
                }
            }
        }
        [System.Serializable]
        public class IntToEventSet
        {
            public int m_integer=0;
            public UnityEvent m_onInvoke= new UnityEvent();
        }
    }

}