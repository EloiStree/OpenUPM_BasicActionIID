using UnityEngine.Events;

namespace Eloi.IntAction
{
    [System.Serializable]
    public class IntAction_IntegerToGenericDataEvent<T> : I_IntActionListener    {
        public UnityEvent<T> m_onValueTriggered;
        public T m_lastTriggeredValue;
        public IntToDataLink<T>[] m_integerToValue = new IntToDataLink<T>[] {};

        public IntAction_IntegerToGenericDataEvent(params IntToDataLink<T>[] parameters)
        {
            m_integerToValue = parameters;
        }

        public void HandleIntegerAction(int integerValue)
        {
            if(m_integerToValue == null || m_integerToValue.Length == 0)
            {
                return;
            }
            for (int i = 0; i < m_integerToValue.Length; i++)
            {
                if (m_integerToValue[i] != null && m_integerToValue[i].GetInteger() == integerValue)
                {
                    m_onValueTriggered?.Invoke(m_integerToValue[i].GetLinkedData());
                    m_lastTriggeredValue = m_integerToValue[i].GetLinkedData();
                }
            }
        }
    }

}