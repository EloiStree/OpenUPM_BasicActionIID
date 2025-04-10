using UnityEngine;

namespace Eloi.IntAction
{
    public abstract class IntActionMono_IntegerToGenericDataEvent<T> :MonoBehaviour, I_IntActionListener
    {

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

        public IntAction_IntegerToGenericDataEvent<T> m_integerToValueEvent= new IntAction_IntegerToGenericDataEvent<T>();

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
    }

}