
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Events;

public class IIDLoadInspectorMono_AudioClip : MonoBehaviour
    {

        public UnityEvent<int, int, AudioClip> m_onLoadIndexIntegerAudio;
        public UnityEvent<int, AudioClip> m_onLoadIntegerAudio;
        public UnityEvent m_onLoad;
        public List<AudioClip> m_audioClips = new List<AudioClip>();

        public bool m_loadOnAwake = false;
        void Awake()
        {
            if (m_loadOnAwake)
                LoadAll();
        }

        [ContextMenu("Load All")]
        private void LoadAll()
        {
            for (int i = 0; i < m_audioClips.Count; i++)
            {
                string[] name_splits = m_audioClips[i].name.Split(new char[] { '.','_'});

                if (name_splits.Length >= 2)
                {
                    bool firstIsInt = int.TryParse(name_splits[0], out int int1);
                    bool secondIsInt = int.TryParse(name_splits[1], out int int2);

                    if (firstIsInt && secondIsInt)
                    {
                        m_onLoadIndexIntegerAudio.Invoke(int1, int2, m_audioClips[i]);
                    }
                    else if (firstIsInt)
                    {
                        m_onLoadIntegerAudio.Invoke(int1, m_audioClips[i]);
                    }
                }
                else if (name_splits.Length >= 1)
                {
                    bool firstIsInt = int.TryParse(name_splits[0], out int int1);
                    if (firstIsInt)
                    {
                        m_onLoadIntegerAudio.Invoke(int1, m_audioClips[i]);
                    }
                }
            }
            m_onLoad.Invoke();
        }
    }

