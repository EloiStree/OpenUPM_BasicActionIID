using UnityEngine;
using UnityEngine.Events;

namespace Eloi.IntAction
{
    public class IntActionMono_SetColorTo : MonoBehaviour, I_IntActionBroadcastListener
    {
        public UnityEvent<Color> m_onColorChanged;

        public IntToColorSet[] m_setColor = new IntToColorSet[] {
            new IntToColorSet(700, Color.red),
            new IntToColorSet(701, Color.green),
            new IntToColorSet(702, Color.blue),
            new IntToColorSet(703, new Color(1, 0.5f, 0, 1)),
            new IntToColorSet(704, Color.yellow),
            new IntToColorSet(705, new Color(0.5f, 0, 0.5f, 1)),
            new IntToColorSet(706, new Color(1, 0.5f, 0.5f, 1)),
            new IntToColorSet(707, Color.cyan),
            new IntToColorSet(708, Color.white),
        };

        public void HandleBroadcastedInteger(int integerValue)
        {
            for (int i = 0; i < m_setColor.Length; i++)
            {
                if (m_setColor[i].m_integer.m_intActionValue == integerValue)
                {
                    m_onColorChanged.Invoke(m_setColor[i].m_colorValueToSet);
                    return;
                }
            }
        }
    }

}