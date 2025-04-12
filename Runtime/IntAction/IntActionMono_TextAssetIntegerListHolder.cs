using UnityEngine;
using UnityEngine.Events;
namespace Eloi.IntAction
{
    /// <summary>
    /// 
    /// I am a class that turn file to int action array id
    /// </summary>
    public class IntActionMono_TextAssetIntegerListHolder : MonoBehaviour
    {

        [Tooltip("Will auto fill MonoBehaviour with I_ContainsTogglePairOfIntegerActionId")]
        public GameObject[] m_targetsToAutoFill;
        public UnityEvent<int[]> m_onIntegerActionLoaded;
        public TextAsset[] m_collectionToLoad;
        public bool m_pushIntegerAtAwake = true;
        public int m_actionsValueIfNull= 5555555;

        [Header("Debug")]
        public IntAction_TextAssetIntegerHolder[]m_actionIntegerCollectionLoaded;
        public int[] m_collectionAsInteger;


        [ContextMenu("Push integer action")]
        public void PushIntegerActions()
        {
            LoadValueAndDescription();
           
            
            m_onIntegerActionLoaded?.Invoke(m_collectionAsInteger);


            if (m_targetsToAutoFill != null)
            {
                foreach (GameObject target in m_targetsToAutoFill)
                {
                    foreach (var component in target.GetComponents<MonoBehaviour>())
                    {
                        if (component == this) continue;
                        if (component is I_ContainsCollectionOfIntegerActionId integerActionId)
                        {
                            integerActionId.SetIntActionIdCollectionWithParams(m_collectionAsInteger);
                        }
                    }
                }
            }
        }

        public void Reset()
        {
            m_targetsToAutoFill = new GameObject[] { this.gameObject };
        }

        [ContextMenu("Load Value and description")]
        public void LoadValueAndDescription()
        {
            m_actionIntegerCollectionLoaded = new IntAction_TextAssetIntegerHolder[m_collectionToLoad.Length];
            for (int i = 0; i < m_collectionToLoad.Length; i++)
            {
                if (m_collectionToLoad[i] == null)
                {
                    m_actionIntegerCollectionLoaded[i] = new IntAction_TextAssetIntegerHolder();
                    m_actionIntegerCollectionLoaded[i].m_loadedInteger.SetWithInteger(m_actionsValueIfNull);
                    continue;
                }
                else
                {
                    m_actionIntegerCollectionLoaded[i] = new IntAction_TextAssetIntegerHolder();
                    m_actionIntegerCollectionLoaded[i].m_integerAsFile = m_collectionToLoad[i];
                    m_actionIntegerCollectionLoaded[i].LoadValueAndDescription();
                }
            }
            int[] values = new int[m_actionIntegerCollectionLoaded.Length];
            for (int i = 0; i < m_actionIntegerCollectionLoaded.Length; i++)
            {
                m_actionIntegerCollectionLoaded[i].GetAsInt(out int value);
                values[i] = value;
            }
            m_collectionAsInteger = values;
        }
        public void Awake()
        {
            if (m_pushIntegerAtAwake)
            {
                PushIntegerActions();
            }
        }
    }
}