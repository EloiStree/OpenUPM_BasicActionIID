using UnityEngine;

namespace Eloi.IntAction
{
    public class IntActionUnityMono_SetLightColor :MonoBehaviour
    {
        public Light m_light;
        public Color m_lightColor;
        public void SetColor(Color setColor)
        {
            m_lightColor = setColor;
            if (m_light != null)
                m_light.color = setColor;
        }
    }
}