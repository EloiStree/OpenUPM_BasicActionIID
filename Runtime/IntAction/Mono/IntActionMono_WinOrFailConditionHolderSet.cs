using System;
using UnityEngine;
using UnityEngine.Events;

namespace Eloi.IntAction
{
    public class IntActionMono_WinOrFailConditionHolderSet : MonoBehaviour, I_IntActionEmitter
    {

        public UnityEvent<int> m_onIntegerAction;
        public int m_lastEmitted;

        public IntActionId m_missionConditionComplete;
        public bool m_isSuccessConditionReached = false;

        public IntActionId m_failConditionReach;
        public bool m_isFailConditionReached = false;

        public void AddEmissionListener(Action<int> p_listener)
        {
            m_onIntegerAction.AddListener(p_listener.Invoke);
        }

        public void RemoveEmissionListener(Action<int> p_listener)
        {
            m_onIntegerAction.RemoveListener(p_listener.Invoke);
        }

        [ContextMenu("Set as fail")]
        public void SetAsFailConditionReach()
        {
            if (!m_isFailConditionReached)
            {
                m_isFailConditionReached = true;
                m_onIntegerAction.Invoke(m_failConditionReach.Value);
                m_lastEmitted = m_failConditionReach.Value;
            }
        }
        [ContextMenu("Set as win")]
        public void SetAsSuccessConditionReach()
        {
            if (!m_isSuccessConditionReached)
            {
                m_isSuccessConditionReached = true;
                m_onIntegerAction.Invoke(m_missionConditionComplete.Value);
                m_lastEmitted = m_missionConditionComplete.Value;
            }
        }

    }


}