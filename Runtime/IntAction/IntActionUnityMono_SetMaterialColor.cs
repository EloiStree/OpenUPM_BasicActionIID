using UnityEngine;

namespace Eloi.IntAction
{
    public class IntActionUnityMono_SetMaterialColor : MonoBehaviour { 
    
        public Material[] m_materials;
        public void SetColor(Color setColor)
        {
            foreach (var item in m_materials)
            {
                if (item != null)
                    item.color = setColor;
            }
        }
    }
}