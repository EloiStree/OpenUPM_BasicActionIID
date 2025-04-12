using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace Eloi.IntAction
{
    public class IntActionMono_ListenToIntegerEmitter : MonoBehaviour, I_IntActionEmitter
    {

        public UnityEvent<int> onIntToRelay;

        public GameObject[] m_sources;
        public bool m_lookForInactive = true;
        public List<MonoBehaviour> m_emitterInChildrens;

        private void Reset()
        {
            m_sources = new GameObject[]{ gameObject };
            RefreshListOfEmitter();
        }

        [ContextMenu("Refresh List")]
        public void RefreshListOfEmitter()
        {
            if (m_sources == null)
                return;
            foreach (var source in m_sources)
            {
                if (source == null)
                    continue;
                m_emitterInChildrens.AddRange(source.GetComponentsInChildren<MonoBehaviour>(m_lookForInactive).Where(t => t is I_IntActionEmitter && t != this));
            }
           
        }

        public void OnEnable()
        {
            RefreshListOfEmitter();
            foreach (var item in m_emitterInChildrens)
            {
                if (item !=null && item != this && item is I_IntActionEmitter)
                    (item as I_IntActionEmitter).AddEmissionListener(PushIn);
            }
        }
        public void OnDisable()
        {
            RefreshListOfEmitter();
            foreach (var item in m_emitterInChildrens)
            {
                if (item != null && item != this && item is I_IntActionEmitter)
                    (item as I_IntActionEmitter).RemoveEmissionListener(PushIn);
            }
        }
        public void PushIn(int integerToEmmit)
        {
            onIntToRelay.Invoke(integerToEmmit);
        }
        public void AddEmissionListener(Action<int> listener)
        {
            onIntToRelay.AddListener(listener.Invoke);
        }
        public void RemoveEmissionListener(Action<int> listener)
        {
            onIntToRelay.RemoveListener(listener.Invoke );
        }
    }

}
