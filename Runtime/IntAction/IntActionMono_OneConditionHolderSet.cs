using UnityEngine;
using UnityEngine.Events;

namespace Eloi.IntAction
{
    public class IntActionMono_OneConditionHolderSet : MonoBehaviour, I_IntegerEmitter {
        public UnityEvent<int> m_onIntegerAction;
        public int m_lastEmitted;
        public bool m_conditionReached = false;
        public IntActionId m_conditionCompleted;
        public void AddEmissionListener(UnityAction<int> listener)
        {
            m_onIntegerAction.AddListener(listener);
        }

        public void RemoveEmissionListener(UnityAction<int> listener)
        {
            m_onIntegerAction.RemoveListener(listener);
        }
        public void NotifyConditionReach() {
            if (!m_conditionReached)
            {
                m_conditionReached = true;
                m_onIntegerAction.Invoke(m_conditionCompleted.m_intActionValue);
                m_lastEmitted = m_conditionCompleted.m_intActionValue;
            }
        }
    }


}