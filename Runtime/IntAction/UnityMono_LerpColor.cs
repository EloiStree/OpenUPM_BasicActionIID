using System;
using UnityEngine;
using UnityEngine.Events;

namespace Eloi.IntAction
{
    public class UnityMono_LerpColor {

        public UnityEvent<Color> m_onColorUpdate;
        public Color m_from;
        public Color m_to;
        public Color m_current;
        public float m_transitionTime;

        public DateTime m_start;
        public DateTime m_end;
        public void SetColor(Color setColor) {
            m_from = m_current;
            m_to = setColor;
            m_start = DateTime.Now;
            m_end = m_start.AddSeconds(m_transitionTime);
        }
        public void SetColor(Color setColor, float transitionTime)
        {
            m_start = DateTime.Now;
            m_end = m_start.AddSeconds(transitionTime);
            m_from = m_current;
            m_to = setColor;
            m_transitionTime = transitionTime;
        }
        public void Update()
        {
            DateTime now = DateTime.Now;
            float percent = (float)(DateTime.Now - m_start).TotalSeconds / m_transitionTime;
            percent = Mathf.Clamp01(percent);
            m_current = Color.Lerp(m_from, m_to, percent);
            m_onColorUpdate.Invoke(m_current);

        }
    }

}