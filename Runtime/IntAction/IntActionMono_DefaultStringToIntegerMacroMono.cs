using System;
using UnityEngine;

namespace Eloi.IntAction {
        public class IntActionMono_DefaultStringToIntegerMacroMono : MonoBehaviour
{


        [ContextMenu("Push last macro in inspector")]
        public void PushLastMacroInInspector()
        {
            PushStringMacro(m_lastPushString);
        }
        private void Reset()
        {
            FetchRelayInParent();
            if (m_relayer == null)
            {
                m_relayer = this.gameObject.AddComponent<IntActionMono_LocalTimeUtcIntegerDelayer>();
            }
        }


        [ContextMenu("Fetch Relay In parent")]
        public void FetchRelayInParent() {
            if (m_relayer == null)
            {
                m_relayer = GetComponentInParent<IntActionMono_LocalTimeUtcIntegerDelayer>();
                
            }

        }
        public IntActionMono_LocalTimeUtcIntegerDelayer m_relayer;
    public string m_lastPushString = "";


    public void PushStringMacro(string macro) {

            m_lastPushString = macro;
            DateTime now = DateTime.UtcNow;
        long millisecondsDelay = 0;
        string [] tokens = macro.Split(new char[] { ' ' }, System.StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < tokens.Length; i++)
        {
                if (int.TryParse(tokens[i], out int integer))
                {
                    m_relayer.PushIntegerNowUtcWithMillisecondsDelay(integer, now, millisecondsDelay);
                }
                else if (tokens[i].EndsWith(">") || tokens[i].EndsWith("+"))
                {
                    tokens[i] = tokens[i].TrimEnd(new char[] { '>', '+' });

                    if (tokens[i].IndexOf(".") > -1 || tokens[i].IndexOf(",") > -1)
                    {

                        if (float.TryParse(tokens[i], out float floatValue))
                        {
                            millisecondsDelay += (long)(floatValue * 1000);
                        }
                    }
                    else if (int.TryParse(tokens[i], out int delayInMs))
                    {
                        millisecondsDelay += delayInMs;
                    }
                }
                else if (tokens[i].StartsWith("--"))
                {
                    tokens[i] = tokens[i].Replace("--", "");

                    if (tokens[i].IndexOf(".") > -1 || tokens[i].IndexOf(",") > -1)
                    {

                        if (float.TryParse(tokens[i], out float floatValue))
                        {
                            millisecondsDelay += (long)(floatValue * 1000);
                        }
                    }
                    else if (int.TryParse(tokens[i], out int delayInMs))
                    {
                        millisecondsDelay += delayInMs;
                    }
                }

                else if (tokens[i] == "|") {

                    millisecondsDelay = 0;
                }
            }
    }
}


}