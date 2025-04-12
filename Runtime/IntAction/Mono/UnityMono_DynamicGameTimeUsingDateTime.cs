using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace Eloi.IntAction
{
    public class UnityMono_DynamicGameTimeUsingDateTime : MonoBehaviour
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


        public void SetGameOverTimeInSeconds(float seconds)
        {
            m_gameOverTimeInSeconds = seconds;
            m_onGamoOverTimeChanged?.Invoke(m_gameOverTimeInSeconds);
        }
        public void SetGameOverTimeInSeconds(int seconds)
        {
            m_gameOverTimeInSeconds = seconds;
            m_onGamoOverTimeChanged?.Invoke(m_gameOverTimeInSeconds);
        }
        public void SetGameOverTimeInMinutes(float minutes)
        {
            m_gameOverTimeInSeconds = minutes * 60;
            m_onGamoOverTimeChanged?.Invoke(m_gameOverTimeInSeconds);
        }
        public void SetGameOverTimeInMinutes(int minutes)
        {
            m_gameOverTimeInSeconds = minutes * 60;
            m_onGamoOverTimeChanged?.Invoke(m_gameOverTimeInSeconds);
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
        public void SetTimeToTimestampSeconds(float seconds)
        {
            m_gameTimeStart = new System.DateTime(1970, 1, 1, 0, 0, 0, System.DateTimeKind.Utc).AddSeconds(seconds);
        }
        public void SetTimeToTimestampMinutes(float minutes)
        {
            m_gameTimeStart = new System.DateTime(1970, 1, 1, 0, 0, 0, System.DateTimeKind.Utc).AddMinutes(minutes);
        }
    }


}