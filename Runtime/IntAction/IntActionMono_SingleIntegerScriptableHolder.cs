using UnityEngine;
using UnityEngine.Events;

namespace Eloi.IntAction
{
    /// <summary>
    /// I am a class that is design to not move in time. I only here to keep a stable action integer value to be used.
    /// </summary>
    public class IntActionMono_SingleIntegerScriptableHolder : MonoBehaviour
    {
        public UnityEvent<int> m_onIntegerActionReceived;
        [SerializeField] SCRIPTABLE_IntActionId m_actionAsInteger;
        public bool m_pushIntegerAtAwake = true;

        public IntActionMono_SingleIntegerScriptableHolder()
        {
        }

        [ContextMenu("Push integer action")]
        public void PushIntegerAction()
        {
            if (m_actionAsInteger == null)
            { return; }
            m_onIntegerActionReceived?.Invoke(m_actionAsInteger.Value);
        }
        private void Awake()
        {
            if (m_pushIntegerAtAwake)
            {
                PushIntegerAction();
            }
        }
    }
}