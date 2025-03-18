using System.Linq;
using UnityEngine;

namespace Eloi.IntAction
{
    public class IntActionMono_BroadcastDiffuser : MonoBehaviour, I_IntActionBroadcastListener
    {
        public int m_lastReceived;

        public GameObject m_source ;
        public MonoBehaviour[] m_childrenListening;

        private void Reset()
        {
            m_source = gameObject;
            RefreshChildrenList();
        }
        private void Awake()
        {
            RefreshChildrenList();
        }

        [ContextMenu("Refresh List")]
        private void RefreshChildrenList()
        {
            m_childrenListening = m_source.GetComponentsInChildren<MonoBehaviour>().Where(t=>t is I_IntActionBroadcastListener && t!=this).ToArray();
        }

        public void PushIn(int integerValue)
        {
            m_lastReceived = integerValue;
            for (int i = 0; i < m_childrenListening.Length; i++)
            {
                if (m_childrenListening[i] == this)
                    continue;
                if (m_childrenListening[i] !=null && 
                    m_childrenListening[i] is I_IntActionBroadcastListener)
                    (m_childrenListening[i] as I_IntActionBroadcastListener).PushIn(integerValue);
            }
        }

    }

}