using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace Eloi.IntAction
{
    public class IntActionMono_SettableGameTimeUtc : MonoBehaviour, I_IntActionBroadcastListener
    {
        [Header("Events")]
        public UnityEvent<float> m_onRelativeGameTimeSecondsUpdated;
        public UnityEvent<long> m_onRelativeGameTimeMillisecondsUpdate;
        public UnityEvent<float> m_onRelativeGameTimePercentUpdated;
        public UnityEvent<float> m_onGamoOverTimeChanged;
        public UnityEvent<float> m_onCountdownUpdateInSeconds;

        [Header("Game Time")]
        public float m_gameOverTimeInSeconds = 300;

        [Header("Debug")]
        public System.DateTime m_gameTimeStart = System.DateTime.Now;
        public float m_relativeGameTimeInSeconds = 0;
        public float m_countdownInSeconds = 0;
        public double m_percentGameTime = 0;


        [Header("Config")]
        public IntActionId m_resetTimeToNow = new IntActionId(600);


        public IntToFloatSet[] m_setGameTime = new IntToFloatSet[] { 
            new IntToFloatSet(601, 60),
            new IntToFloatSet(602, 120),
            new IntToFloatSet(603, 180),
            new IntToFloatSet(604, 240),
            new IntToFloatSet(605, 300),
            new IntToFloatSet(606, 360),
            new IntToFloatSet(607, 420),
            new IntToFloatSet(608, 480),
            new IntToFloatSet(609, 540),
            new IntToFloatSet(610, 600),

        };
        public IntToFloatAppend[] m_appendGameTime= new IntToFloatAppend[] { 
        
            new IntToFloatAppend(611, 60),
            new IntToFloatAppend(612, 120),
            new IntToFloatAppend(613, 180),
            new IntToFloatAppend(614, 240),
            new IntToFloatAppend(615, 300),
            new IntToFloatAppend(616, 360),
            new IntToFloatAppend(617, 420),
            new IntToFloatAppend(618, 480),
            new IntToFloatAppend(619, 540),
            new IntToFloatAppend(620, 600),
        } ;



        private void Awake()
        {
            SetTimerToNow();
        }
        public void Update()
        {
            m_relativeGameTimeInSeconds = (float)(System.DateTime.UtcNow - m_gameTimeStart).TotalSeconds;
            if (m_gameOverTimeInSeconds == 0)
                m_percentGameTime = 1;
            else 
                m_percentGameTime = m_relativeGameTimeInSeconds / m_gameOverTimeInSeconds;
            m_onRelativeGameTimeSecondsUpdated.Invoke(m_relativeGameTimeInSeconds);
            m_onRelativeGameTimeMillisecondsUpdate.Invoke((long)(m_relativeGameTimeInSeconds * 1000));
            m_onRelativeGameTimePercentUpdated.Invoke((float)m_percentGameTime);
            m_countdownInSeconds = Mathf.Clamp( m_gameOverTimeInSeconds - m_relativeGameTimeInSeconds, 0, m_gameOverTimeInSeconds);
            m_onCountdownUpdateInSeconds.Invoke(m_countdownInSeconds);
        }

        public void HandleBroadcastedInteger(int integerValue) {

            if (m_resetTimeToNow.m_intActionValue == integerValue)
            {
                SetTimerToNow();
                return;
            }
            for (int i = 0; i < m_setGameTime.Length; i++)
            {
                if (m_setGameTime[i].m_integer.m_intActionValue == integerValue)
                {
                    m_gameOverTimeInSeconds = m_setGameTime[i].m_floatValueToSet;
                    m_onGamoOverTimeChanged.Invoke(m_gameOverTimeInSeconds);
                    return;
                }
            }
            for (int i = 0; i < m_appendGameTime.Length; i++)
            {
                if (m_appendGameTime[i].m_integer.m_intActionValue == integerValue)
                {
                    m_gameOverTimeInSeconds += m_appendGameTime[i].m_floatValuetoAppend;
                    m_onGamoOverTimeChanged.Invoke(m_gameOverTimeInSeconds);
                    return;
                }
            }
        }


        [ContextMenu("SetTimerToNow")]
        public void SetTimerToNow()
        {
            m_gameTimeStart = System.DateTime.UtcNow;
        }
        public void SetTimerToTimestampMilliseconds(ulong milliseconds)
        {
            m_gameTimeStart = new System.DateTime(1970, 1, 1, 0, 0, 0, System.DateTimeKind.Utc).AddMilliseconds(milliseconds);
        }
        public void SetTimerToTimestampMilliseconds(long milliseconds)
        {
            m_gameTimeStart = new System.DateTime(1970, 1, 1, 0, 0, 0, System.DateTimeKind.Utc).AddMilliseconds(milliseconds);
        }
        public void SetTimeToTimestampSeconds(long seconds)
        {
            m_gameTimeStart = new System.DateTime(1970, 1, 1, 0, 0, 0, System.DateTimeKind.Utc).AddSeconds(seconds);
        }
    }

    [System.Serializable]
    public class IntToFloatSet
    {
        [SerializeField] private string m_label;
        public IntActionId m_integer;
        public float m_floatValueToSet;

        public IntToFloatSet(int integer, float valueToSet)
        {
            m_integer = new IntActionId(integer);
            m_floatValueToSet = valueToSet;
        }
    }

    public class IntToFloatAppend
    {
        [SerializeField] private string m_label;
        public IntActionId m_integer;
        public float m_floatValuetoAppend;

        public IntToFloatAppend(int integer, float valueToAppend)
        {
            m_integer = new IntActionId(integer);
            m_floatValuetoAppend = valueToAppend;
        }
    }

}