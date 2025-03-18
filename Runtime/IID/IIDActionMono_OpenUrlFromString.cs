using UnityEngine;
using UnityEngine.UI;

public class IIDActionMono_OpenUrlFromString : MonoBehaviour
{
    public void OpenApplicationUrl(string url)
    {
        Application.OpenURL(url);
    }
}