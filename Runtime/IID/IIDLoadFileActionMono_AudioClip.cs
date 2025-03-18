using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Events;

public class IIDLoadFileActionMono_AudioClip : MonoBehaviour
{
    public UnityEvent<int, int, AudioClip> m_onLoadIndexIntegerAudio;
    public UnityEvent<int, AudioClip> m_onLoadIntegerAudio;
    public UnityEvent m_onLoaded;
    public List<AudioClip> m_audioClips = new List<AudioClip>();

    public string m_directoryPathAbsolute = "Assets/";
    public string[] m_fileExtension = new string[] { ".ogg", ".mp3", ".wav" };

    public bool m_loadOnAwake = true;
    void Awake()
    {
        if (m_loadOnAwake)
            LoadAll();
    }

    public void SetAbstractDirectoryPathToLoad(string path)
    {
        m_directoryPathAbsolute = path;
    }


     void LoadFilesInRoot(string root, out List<string> files)
    {
        files = new List<string>();
        foreach (string ext in m_fileExtension)
        {
            string[] tempFiles = Directory.GetFiles(root, "*" + ext, SearchOption.AllDirectories);
            files.AddRange(tempFiles);
        }
    }

     void LoadAudioFromPath(string filePath, out AudioClip clip)
    {
        clip = null; // Initialize the AudioClip to null

        if (!File.Exists(filePath))
        {
            return;
        }
        try
        {

            // Load the audio data from the file path
            byte[] audioData = System.IO.File.ReadAllBytes(filePath);
            string fileName = Path.GetFileName(filePath);

            // Create a new AudioClip and load the audio data
            clip = AudioClip.Create(Path.GetFileNameWithoutExtension(filePath), audioData.Length, 1, 44100, false);
            clip.LoadAudioData();
            clip.name = fileName;
        }catch(System.Exception e)
        {
            Debug.LogError(e);
            return;
        }
    }
    [ContextMenu("Load All")]
    private void LoadAll()
    {

        LoadFilesInRoot(m_directoryPathAbsolute, out List<string> files);
        m_audioClips.Clear();
        for (int i = 0; i < files.Count; i++)
        {
            LoadAudioFromPath(files[i], out AudioClip clip);
            m_audioClips.Add(clip);
        }

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
        m_onLoaded.Invoke();
    } 
}

