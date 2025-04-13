using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Eloi.IntAction
{
    public class IntActionMono_BroadcastDiffuser : MonoBehaviour, I_IntActionListener
    {
        public int m_lastReceived;

        public GameObject [] m_sources ;
        public List<MonoBehaviour> m_childrenListening;

        private void Reset()
        {
            m_sources = new GameObject[] { this.gameObject };
            RefreshChildrenList();
        }
        private void Awake()
        {
            RefreshChildrenList();
        }
        public bool m_lookForInactive=true;
        [ContextMenu("Refresh List")]
        private void RefreshChildrenList()
        {
            foreach (GameObject source in m_sources) {
                if (source == null)
                    continue;
                m_childrenListening.AddRange(source.GetComponentsInChildren<MonoBehaviour>(m_lookForInactive).Where(t => t is I_IntActionListener && t != this));
            }
            m_childrenListening = m_childrenListening.Where(k=>k!=null).Distinct().ToList();
            m_childrenListening.Remove(this);
        }

        public void HandleIntegerAction(int integerValue)
        {
            m_lastReceived = integerValue;
            for (int i = 0; i < m_childrenListening.Count; i++)
            {
                if (m_childrenListening[i] == this)
                    continue;
                if (m_childrenListening[i] !=null && 
                    m_childrenListening[i] is I_IntActionListener)
                    (m_childrenListening[i] as I_IntActionListener).HandleIntegerAction(integerValue);
            }
        }

    }

}