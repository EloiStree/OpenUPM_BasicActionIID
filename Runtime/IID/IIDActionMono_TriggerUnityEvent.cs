using UnityEngine;
using UnityEngine.Events;

public class IIDActionMono_TriggerUnityEvent :MonoBehaviour
{

    [System.Serializable]
    public class IntegerEvent{
        public string m_description;
        public int m_integer;
        public UnityEvent m_onMatching;

    }

    [System.Serializable]
    public class IndexIntegerEvent{
        public string m_description;
        public int m_index;
        public int m_integer;
        public UnityEvent m_onMatching;

    }



    public IntegerEvent[] m_integerEvents;
    public IndexIntegerEvent[] m_indexIntegerEvents;


    public void Trigger(STRUCT_ReceivedIID receivedIID)
    {
        Trigger(receivedIID.integer);
        Trigger(receivedIID.index, receivedIID.integer);

    }

    public void Trigger(int integer)
    {
        for (int i = 0; i < m_integerEvents.Length; i++)
        {
            if (m_integerEvents[i].m_integer == integer)
            {
                m_integerEvents[i].m_onMatching.Invoke();
            }
        }
    }

    public void Trigger(int index, int integer)
    {

        for (int i = 0; i < m_indexIntegerEvents.Length; i++)
        {
            if (m_indexIntegerEvents[i].m_index == index && m_indexIntegerEvents[i].m_integer == integer)
            {
                m_indexIntegerEvents[i].m_onMatching.Invoke();

            }
        }
    }

}






























