using UnityEngine;

namespace Eloi.IntAction
{
    public class IntActionUnityMono_SetRendererColor : MonoBehaviour
    {
        public Renderer[] m_renderers;
        public void SetColor(Color setColor)
        {
            foreach (var item in m_renderers)
            {
                if (item != null && item.material!=null)
                    item.material.color = setColor;
            }
        }
    }
}