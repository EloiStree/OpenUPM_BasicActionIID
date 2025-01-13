using UnityEngine;
/// <summary>
/// I am a class that store description of what the integer action should be doing;
/// </summary>
/// [System.Serializable]
[System.Serializable]
public class IntentDescription
{
    [Tooltip("Label in two words what should do the action.")]
    public string m_label;

    [Tooltip("Describe in one line what it is suppose do to do")]
    public string m_oneLineDescription;

    [Tooltip("Give some explaination of what the action suppose to do in text or markdown format")]
    [TextArea(0,5)]
    public string m_textDescription;

    [Tooltip("If you need more that a text, you should store the manual in a web page markdown format file.")]
    [TextArea(0, 1)]
    public string m_urlDocumentation;
}


























