using UnityEngine;
using UnityEngine.Events;

namespace Eloi.IntAction
{
    public class IntActionMono_WinOrFailConditionHolderSet : MonoBehaviour, I_IntegerEmitter
    {

        public UnityEvent<int> m_onIntegerAction;
        public int m_lastEmitted;

        public IntActionId m_missionConditionComplete;
        public bool m_isSuccessConditionReached = false;

        public IntActionId m_failConditionReach;
        public bool m_isFailConditionReached = false;

        public void AddEmissionListener(UnityAction<int> p_listener)
        {
            m_onIntegerAction.AddListener(p_listener);
        }

        public void RemoveEmissionListener(UnityAction<int> p_listener)
        {
            m_onIntegerAction.RemoveListener(p_listener);
        }

        [ContextMenu("Set as fail")]
        public void SetAsFailConditionReach()
        {
            if (!m_isFailConditionReached)
            {
                m_isFailConditionReached = true;
                m_onIntegerAction.Invoke(m_failConditionReach.m_intActionValue);
                m_lastEmitted = m_failConditionReach.m_intActionValue;
            }
        }
        [ContextMenu("Set as win")]
        public void SetAsSuccessConditionReach()
        {
            if (!m_isSuccessConditionReached)
            {
                m_isSuccessConditionReached = true;
                m_onIntegerAction.Invoke(m_missionConditionComplete.m_intActionValue);
                m_lastEmitted = m_missionConditionComplete.m_intActionValue;
            }
        }

    }


}