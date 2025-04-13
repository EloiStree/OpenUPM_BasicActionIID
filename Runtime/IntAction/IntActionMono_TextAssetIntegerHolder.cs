using UnityEngine;
using UnityEngine.Events;

namespace Eloi.IntAction
{

    /// <summary>
    ///  I am a class that aimed to store integer on the long term with a short description reminder.
    /// </summary>
    public class IntActionMono_TextAssetIntegerHolder : MonoBehaviour
    {
        public GameObject[] m_targetsToAutoFill; 
        public UnityEvent<int> m_onIntegerActionLoaded;
        [SerializeField] IntAction_TextAssetIntegerHolder m_actionAsInteger;
        public bool m_pushIntegerAtAwake = true;


        private void Reset()
        {
            m_targetsToAutoFill = new GameObject[] { gameObject };
        }


        [ContextMenu("Push integer action")]
        public void PushIntegerAction()
        {
            if (m_actionAsInteger == null)
            { return; }
            LoadFromTextFile();
            m_actionAsInteger.GetAsIntActionId(out IntActionId integerActionId);
            m_onIntegerActionLoaded?.Invoke(integerActionId.Value);
            AutoFillWithLoaded();
        }
        public void SetTextFile(TextAsset textFile)
        {
            m_actionAsInteger.SetTextFile( textFile);
        }

        public void GetTextFile(out TextAsset textFile)
        {
            textFile = m_actionAsInteger.m_integerAsFile;
        }
        public void GetTextInTextAsset(out string text)
        {
            text = m_actionAsInteger.m_integerAsFile.text;
        }
        [ContextMenu("Auto Field With loaded")]
        public void AutoFillWithLoaded()
        {
            if (m_targetsToAutoFill == null)
            { return; }
            foreach(GameObject gameObject in m_targetsToAutoFill)
            {
                if (gameObject == null)
                { continue; }

                I_ContainsOneIntegerActionId[] integerHolders = gameObject.GetComponents<I_ContainsOneIntegerActionId>();
                foreach (I_ContainsOneIntegerActionId integerHolder in integerHolders)
                {
                    if (integerHolder == null)
                    { continue; }
                    integerHolder.SetIntActionId(m_actionAsInteger.GetAsInt());
                }
            }
        }

        [ContextMenu("Load From Text File")]
        public void LoadFromTextFile()
        {
            if (m_actionAsInteger == null)
            { return; }
            m_actionAsInteger.LoadValueAndDescription();
        }
        private void Awake()
        {
            if (m_pushIntegerAtAwake)
            {
                PushIntegerAction();
            }
        }
    }
}