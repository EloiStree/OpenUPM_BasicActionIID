using UnityEngine;

namespace Eloi.IntAction
{
    public class IntActionUnityMono_SetCameraBackgroundColor: MonoBehaviour
    {
        public Camera m_camera;
        public Color m_backgroundColor;
        public void SetColor(Color setColor)
        {
            m_backgroundColor = setColor;
            if (m_camera !=null)
            m_camera.backgroundColor = setColor;
        }
    }
}