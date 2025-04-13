using System.Collections.Generic;
using UnityEngine.Events;

namespace Eloi.IntAction
{

    [System.Serializable]
    public class IntAction_IntegerToOneGenericDataEvent<T> : I_IntActionListener, I_ContainsOneIntegerActionId
    {
        public UnityEvent<T> m_onValueTriggered=new();
        public IntActionId m_integerToTrigger=new IntActionId();
        public T m_lastTriggeredValue =default;

        public void GetIntActionId(out IntActionId integerActionId)
        {
            integerActionId = m_integerToTrigger;
        }

        public void HandleIntegerAction(int integerValue)
        {
            if (m_integerToTrigger == null)
            {
                return;
            }
            if (m_integerToTrigger.Value == integerValue)
            {
                m_onValueTriggered?.Invoke(m_lastTriggeredValue);
            }
        }

        public void SetIntActionId(IntActionId integerActionId)
        {
            m_integerToTrigger = integerActionId;
        }

        public void SetIntActionId(int integerActionId)
        {
           
                m_integerToTrigger.Value = integerActionId;
            
        }
    }
    [System.Serializable]
    public class IntAction_IntegerToGenericDataEvent<T> : I_IntActionListener  , I_ContainsCollectionOfIntegerActionId
    {
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
        public void GetIntActionIdCollection(out IEnumerable<IntActionId> integerActionIdList)
        {
            List<IntActionId> integerActionIdListTemp = new List<IntActionId>();
            foreach (IntToDataLink<T> integerToValue in m_integerToValue)
            {
                if (integerToValue == null)
                { continue; }
                integerToValue.GetIngeter(out IntActionId integerActionId);
                integerActionIdListTemp.Add(integerActionId);
            }
            integerActionIdList = integerActionIdListTemp;
        }
        public void SetIntActionIdCollection(IEnumerable<IntActionId> integerActionIdList)
        {
            if (integerActionIdList == null)
            {
                return;
            }

            int arraySize = m_integerToValue.Length;
            int count = 0;
            foreach (IntActionId id  in integerActionIdList)
            {
                if (id == null)
                { continue; }

                if (count >= arraySize)
                {
                    break;
                }
                if (id!=null && m_integerToValue[count] != null)
                {
                    m_integerToValue[count].SetIngeter(id);
                }

                count++;
            }
        }

        public void SetIntActionIdCollectionWithParams(params IntActionId[] integerActionIdList)
        {
            SetIntActionIdCollection(integerActionIdList);
        }

        public void SetIntActionIdWithIntegerArray(int[] integerActionIdList) {

            SetIntActionIdCollectionWithParams(integerActionIdList);
        }
        public void SetIntActionIdCollectionWithParams(params int[] integerActionIdList)
        {

            if (integerActionIdList == null)
            {
                return;
            }
            int arraySize = m_integerToValue.Length;
            int count = 0;
            foreach (int id in integerActionIdList)
            {
                if (count >= arraySize)
                {
                    break;
                }
                if (m_integerToValue[count] != null)
                {
                    m_integerToValue[count].SetIngeter(id);
                }
                count++;
            }
        }
    }

}