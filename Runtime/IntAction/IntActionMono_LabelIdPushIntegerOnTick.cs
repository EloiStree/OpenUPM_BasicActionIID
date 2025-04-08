using UnityEngine;
using UnityEngine.Events;

namespace Eloi.IntAction
{
    public class IntActionMono_LabelIdPushIntegerOnTick : DefaultIntegerEmitterEventMono
    {
        public string m_label = "Label";
        public int m_integerToPushOnTick;
        public UnityEvent<string> m_onLabelChanged;
        [TextArea(0, 2)]
        public string m_labelFormat = "{0}({1})";

        private void OnValidate()
        {

            m_onLabelChanged?.Invoke(GetLabelIdAsString());

        }
        public string GetLabelIdAsString()
        {
            if (string.IsNullOrEmpty(m_label))
            {
                return m_integerToPushOnTick.ToString();
            }
            return string.Format(m_labelFormat, m_label, m_integerToPushOnTick);
        }

        private void Awake()
        {
            m_onLabelChanged.Invoke(GetLabelIdAsString());
        }

        private void OnEnable()
        {
            m_onLabelChanged.Invoke(GetLabelIdAsString());
        }
        public void SetLabelText(string label)
        {
            m_label = label;
            m_onLabelChanged.Invoke(GetLabelIdAsString());
        }

        [ContextMenu("Tick Invoke")]
        public void TickInvoke()
        {
            m_onIntegerActionEmitted.Invoke((int)m_integerToPushOnTick);
        }
    }

}