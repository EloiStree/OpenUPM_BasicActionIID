using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace Eloi.IntAction
{
    public class IntActionMono_ListenToIntegerEmitter : MonoBehaviour, I_IntegerEmitter
    {

        public UnityEvent<int> onIntToRelay;

        public GameObject m_source;
        public MonoBehaviour[] m_emitterInChildrens;

        private void Reset()
        {
            m_source = gameObject;
            RefreshListOfEmitter();
        }

        [ContextMenu("Refresh List")]
        public void RefreshListOfEmitter()
        {
            if (m_source == null)
                return;
            m_emitterInChildrens = m_source.GetComponentsInChildren<MonoBehaviour>().Where((p) => p is I_IntegerEmitter && p != this).ToArray();
           

        }

        public void OnEnable()
        {
            RefreshListOfEmitter();
            foreach (var item in m_emitterInChildrens)
            {
                if (item !=null && item != this && item is I_IntegerEmitter)
                    (item as I_IntegerEmitter).AddEmissionListener(PushIn);
            }
        }
        public void OnDisable()
        {
            RefreshListOfEmitter();
            foreach (var item in m_emitterInChildrens)
            {
                if (item != null && item != this && item is I_IntegerEmitter)
                    (item as I_IntegerEmitter).RemoveEmissionListener(PushIn);
            }
        }
        public void PushIn(int integerToEmmit)
        {
            onIntToRelay.Invoke(integerToEmmit);
        }
        public void AddEmissionListener(UnityAction<int> listener)
        {
            onIntToRelay.AddListener(listener);
        }
        public void RemoveEmissionListener(UnityAction<int> listener)
        {
            onIntToRelay.RemoveListener(listener);
        }
    }

}
