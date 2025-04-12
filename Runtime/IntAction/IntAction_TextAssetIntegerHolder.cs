using System;
using UnityEngine;

namespace Eloi.IntAction
{
    /// <summary>
    /// I am a class that converve what integer action should be used with a description from a file.
    /// You can use SCRITPABLE_IntegerActionId but I have better trust in file system to not break through time.
    /// </summary>
    [System.Serializable]
    public class IntAction_TextAssetIntegerHolder {

        public string m_loadedDescription;
        public IntActionId m_loadedInteger;
        [ContextMenuItem("Load", nameof(LoadValueAndDescription))]
        public TextAsset m_integerAsFile;

        public void GetAsIntActionId(out IntActionId integerActionId)
        {
            integerActionId = m_loadedInteger;
        }
        public void GetAsInt(out int integerValue)
        {
            integerValue = m_loadedInteger.Value;
        }
        public int GetAsInt()
        {
            return m_loadedInteger.Value;
        }
        public IntActionId GetAsIntActionId()
        {
            return m_loadedInteger;
        }
        public void GetTextDescription(out string description)
        {
            description = m_loadedDescription;
        }
        public string GetTextDescription()
        {
            return m_loadedDescription;
        }

        [ContextMenu("Load Value and descirption")]
        public void LoadValueAndDescription()
        {
            if (m_integerAsFile == null)
            {
                return;
            }

            string fileTilte = m_integerAsFile.name;
            if (int.TryParse(fileTilte, out int integerValue))
            {
                m_loadedInteger = integerValue;
                m_loadedDescription = m_integerAsFile.text;
            }
            else
            {
                string text = m_integerAsFile.text;
                if (int.TryParse(text, out int integer))
                {
                    m_loadedInteger = integer;
                    m_loadedDescription = fileTilte;
                }
                else
                {

                    string[] split = m_integerAsFile.name.Split(new char[] {' ', '_', '-'});
                    if (split.Length > 1)
                    {
                        string integerString = split[0];
                        if (int.TryParse(integerString, out int integerValue2))
                        {
                            m_loadedInteger = integerValue2;
                            m_loadedDescription = m_integerAsFile.text;
                            if (string.IsNullOrEmpty(m_loadedDescription))
                            {
                                m_loadedDescription = string.Join(" ", split, 1, split.Length - 1);
                            }
                        }
                    }
                }
            }
        }

        public void SetTextFile(TextAsset textFile)
        {
            m_integerAsFile = textFile;
            if (m_integerAsFile != null)
            {
                LoadValueAndDescription();
            }
        }
    }
}