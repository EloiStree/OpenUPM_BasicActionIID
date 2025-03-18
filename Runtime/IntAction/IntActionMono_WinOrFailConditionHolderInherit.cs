using Eloi.IntAction;
using UnityEngine;
using UnityEngine.Events;

namespace Eloi.IntAction
{


public class IntActionMono_WinOrFailConditionHolderInherit : MonoBehaviour, I_IntegerEmitter
{

    public UnityEvent<int> m_onIntegerAction;
        public int m_lastEmitted;

    public IntActionId m_missionConditionComplete;
    public IntBoolReachConditioMono m_successCondition;
    public bool m_isSuccessConditionReached = false;

    public IntActionId m_failConditionReach;
    public IntBoolReachConditioMono m_failCondition;
    public bool m_isFailConditionReached = false;

        public void AddEmissionListener(UnityAction<int> p_listener)
        {
            m_onIntegerAction.AddListener(p_listener);
        }

        public void RemoveEmissionListener(UnityAction<int> p_listener)
        {
            m_onIntegerAction.RemoveListener(p_listener);
        }

        public void Update()
    {
        if (m_failCondition != null && !m_isFailConditionReached && m_failCondition.IsConditionTrue())
        {
            m_isFailConditionReached = true;
            m_onIntegerAction.Invoke(m_failConditionReach.m_intActionValue);
                m_lastEmitted = m_failConditionReach.m_intActionValue;
            }
        if (m_successCondition != null && !m_isSuccessConditionReached && m_successCondition.IsConditionTrue())
        {
            m_isSuccessConditionReached = true;
            m_onIntegerAction.Invoke(m_missionConditionComplete.m_intActionValue);
                m_lastEmitted = m_missionConditionComplete.m_intActionValue;    
            }
    }
}


}