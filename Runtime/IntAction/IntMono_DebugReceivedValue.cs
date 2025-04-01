using UnityEngine;

namespace Eloi.IntegerLobby
{
    public class IntMono_DebugReceivedValue : MonoBehaviour
    {
        public int[] m_receivedValue = new int[10];

        public void PushIn(int value)
        {
            for (int i = m_receivedValue.Length - 1; i > 0; i--)
            {
                m_receivedValue[i] = m_receivedValue[i - 1];
            }
            m_receivedValue[0] = value;
        }

    }



}
