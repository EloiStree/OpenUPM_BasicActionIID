using UnityEngine;

namespace Eloi.IntAction
{
    public class IntActionMono_GetToggleInGroupInfoUnity : MonoBehaviour {

        public IntAction_GetToggleInGroupInfoUnity m_observedGroup;

        public bool m_useUpdate = false;
        public bool m_useOneSecondsInvoke = false;


        private void Awake()
        {
            if (m_useOneSecondsInvoke)
            {
                InvokeRepeating(nameof(UpdateStateOfToggles), 1f, 1f);
            }
        }

        [ContextMenu("Update Toggle")]
        public void UpdateStateOfToggles()
        {
            m_observedGroup.UpdateStateOfToggles();
        }

        void Update()
        {
            if (m_useUpdate)
            {
                UpdateStateOfToggles();
            }
        }
    }
}