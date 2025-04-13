using System.Collections.Generic;
using UnityEngine;

namespace Eloi.IntAction
{
    public abstract class IntActionMono_IntegerToOneGenericDataEvent<T> : MonoBehaviour, I_IntActionListener, I_ContainsOneIntegerActionId
    {

        public IntAction_IntegerToOneGenericDataEvent<T> m_integerToValueEvent= new IntAction.IntAction_IntegerToOneGenericDataEvent<T>();

        public void GetIntActionId(out IntActionId integerActionId)
        {
            m_integerToValueEvent.GetIntActionId(out integerActionId);
        }

        public void HandleIntegerAction(int integerValue)
        {
            m_integerToValueEvent.HandleIntegerAction(integerValue);
        }

        public void SetIntActionId(IntActionId integerActionId)
        {
            m_integerToValueEvent.SetIntActionId(integerActionId);
        }

        public void SetIntActionId(int integerActionId)
        {
            m_integerToValueEvent.SetIntActionId(integerActionId);
        }
    }
    public abstract class IntActionMono_IntegerToGenericDataEvent<T> :MonoBehaviour, I_IntActionListener, I_ContainsCollectionOfIntegerActionId
    {

        public IntAction_IntegerToGenericDataEvent<T> m_integerToValueEvent= new IntAction_IntegerToGenericDataEvent<T>();
        public void Reset()
        {
            IntToDataLink<T>[] parameters;
            GetDefaultValueForReset(out parameters);
            if (parameters == null || parameters.Length == 0)
            {
                return;
            }
            m_integerToValueEvent = new IntAction_IntegerToGenericDataEvent<T>(parameters);
        }

        public abstract void GetDefaultValueForReset(out IntToDataLink<T>[] parameters);


        public IntActionMono_IntegerToGenericDataEvent()
        {
        }

        public IntActionMono_IntegerToGenericDataEvent(params IntToDataLink<T>[] parameters)
        {
            m_integerToValueEvent = new IntAction_IntegerToGenericDataEvent<T>(parameters);
        }

        public void HandleIntegerAction(int integerValue)
        {
            m_integerToValueEvent.HandleIntegerAction(integerValue);
        }

        public void GetIntActionIdCollection(out IEnumerable<IntActionId> integerActionIdList)
        {
            m_integerToValueEvent.GetIntActionIdCollection(out integerActionIdList);
        }

        public void SetIntActionIdCollection(IEnumerable<IntActionId> integerActionIdList)
        {
            m_integerToValueEvent.SetIntActionIdCollection(integerActionIdList);
        }

        public void SetIntActionIdCollectionWithParams(params IntActionId[] integerActionIdList)
        {
            m_integerToValueEvent.SetIntActionIdCollectionWithParams(integerActionIdList);
        }

        public void SetIntActionIdCollectionWithParams(params int[] integerActionIdList)
        {
            m_integerToValueEvent.SetIntActionIdCollectionWithParams(integerActionIdList);
        }
    }

}