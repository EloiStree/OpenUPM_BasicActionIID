using UnityEngine;

public class IntConditionMono_IsGameObjectDisableOrDestroy : IntBoolReachConditioMono
{
    public GameObject m_target;
    public override bool IsConditionTrue()
    {
        return m_target == null || !m_target.activeInHierarchy;
    }
}
