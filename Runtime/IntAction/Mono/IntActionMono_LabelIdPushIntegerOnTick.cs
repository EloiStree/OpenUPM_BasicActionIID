﻿using UnityEngine;
using UnityEngine.Events;

namespace Eloi.IntAction
{
    public class IntActionMono_LabelIdPushIntegerOnTick : DefaultIntegerEmitterEventMono, I_ContainsOneIntegerActionId
    {
        public string m_label = "Label";
        public IntActionId m_integerToPushOnTick;
        public UnityEvent<string> m_onLabelChanged;
        [TextArea(0, 2)]
        public string m_labelFormat = "{0}({1})";

        private void OnValidate()
        {
            RefreshUI();
        }

        private void RefreshUI()
        {
            m_onLabelChanged?.Invoke(GetLabelIdAsString());
        }

        public string GetLabelIdAsString()
        {
            if (string.IsNullOrEmpty(m_label))
            {
                return m_integerToPushOnTick.ToString();
            }
            return string.Format(m_labelFormat, m_label, m_integerToPushOnTick.Value);
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

        public void GetIntActionId(out IntActionId integerActionId)
        {
            integerActionId = m_integerToPushOnTick;
        }

        public void SetIntActionId(IntActionId integerActionId)
        {
            m_integerToPushOnTick = integerActionId;
            RefreshUI();
        }

        public void SetIntActionId(int integerActionId)
        {
            m_integerToPushOnTick = new IntActionId(integerActionId);
            RefreshUI();
        }
    }

}