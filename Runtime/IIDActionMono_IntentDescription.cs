using UnityEngine;
using UnityEngine.Events;

public class IIDActionMono_IntentDescription : MonoBehaviour
{
    public IntentDescription m_data;
    public UnityEvent<string> m_onLabelSet;
    public UnityEvent<string> m_onOneLineSet;
    public UnityEvent<string> m_onTextDescriptionSet;
    public UnityEvent<string> m_onUrlSet;

    public void SetWith(IntentDescription description ) {

        m_data = description;
        m_onLabelSet.Invoke( description.m_label);
        m_onOneLineSet.Invoke( description.m_oneLineDescription);
        m_onTextDescriptionSet.Invoke( description.m_textDescription);
        m_onUrlSet.Invoke( description.m_urlDocumentation);
    }

    [ContextMenu("Open URL")]
    public void OpenCurrentUrl() { 
        Application.OpenURL(m_data.m_urlDocumentation);
    }
}
