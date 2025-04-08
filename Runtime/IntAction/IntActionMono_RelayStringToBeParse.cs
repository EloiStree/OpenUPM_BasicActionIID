using UnityEngine;
using UnityEngine.Events;

namespace Eloi.IntAction {
    public class IntActionMono_RelayStringToBeParse : MonoBehaviour
    {
        public string m_stringToParse = "";
        public UnityEvent<string> m_onStringParsed = new UnityEvent<string>();
        void InvokeStringToParse()
        {
            m_onStringParsed.Invoke(m_stringToParse);
        }
        public void SetTextToParseWhenSubmit(string text)
        {
            m_stringToParse = text;
        }
        public void SetTextToParseAndSubmit(string text)
        {
            m_stringToParse = text;
            Submit();
        }
        [ContextMenu("Submit Text to UnityEvent")]
        public void Submit()
        {
            InvokeStringToParse();
        }
    }


}