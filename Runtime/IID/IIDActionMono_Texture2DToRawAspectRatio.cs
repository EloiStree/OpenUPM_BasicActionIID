using UnityEngine;
using UnityEngine.UI;

public class IIDActionMono_Texture2DToRawAspectRatio : MonoBehaviour
{

    public IIDAction_Texture2DToRawAspectRatio m_target;
    public void PushIn(Texture texture)
    {
        if( m_target == null)
            return;
        m_target.PushIn(texture);
    }

    public void PushIn(Texture2D texture)
    {
        if (m_target == null)
            return;

        m_target.PushIn(texture);
    }
}
[System.Serializable]
public class IIDAction_Texture2DToRawAspectRatio 
{
    public RawImage m_rawImage;
    public AspectRatioFitter m_ratioFitter;

    [Header("Debug")]
    public Texture2D m_textureReceived;

    public void PushIn(Texture texture)
    {
        if (texture is Texture2D)
            PushIn(texture as Texture2D);
    }

    public void PushIn(Texture2D texture)
    {
        m_textureReceived = texture;
        if (m_rawImage != null)
            m_rawImage.texture = texture;
        if (m_ratioFitter != null && texture!=null)
            m_ratioFitter.aspectRatio = (float)texture.width / texture.height;
    }
}