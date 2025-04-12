using UnityEngine;
using UnityEngine.Events;

namespace Eloi.IntAction
{

    public class IntLobbyActionMono_PushAndDoWhenReceived : DefaultIntegerListenAndEmitterEventMono
    {

        public IntActionId m_actionToTrigger;
        public UnityEvent m_onIntegerReceivedAction;

        [ContextMenu("Emit the integer")]
        public void EmitTheIntegerAction()
        {
            base.SendInteger(m_actionToTrigger.Value);
        }

        protected override void ChildrenHandlerForIntegerAction(int integerValue)
        {
            if (m_actionToTrigger.Value == integerValue)
            {
                m_onIntegerReceivedAction?.Invoke();
            }
        }
    }

    public class UnityMono_LoopClipSeveralTime : MonoBehaviour 
    {

        public AudioSource m_audioSource;
        public int m_loopCount = 4;

        public float m_secondPlayingCountSeconds;



        private void Reset()
        {
            m_audioSource = GetComponent<AudioSource>();
            if (m_audioSource == null)
            {
                m_audioSource = gameObject.AddComponent<AudioSource>();
            }
            m_audioSource.loop = true;
            m_audioSource.playOnAwake = false;
        }



        [ContextMenu("Play Sound")]
        public void PlaySound()
        {
            if (m_audioSource == null)
                return;
            m_audioSource.Play();
            m_secondPlayingCountSeconds = m_audioSource.clip.length * m_loopCount;
        }

        private void Update()
        {
            if(m_secondPlayingCountSeconds > 0f)
            {
                m_secondPlayingCountSeconds -= Time.deltaTime;
            }
        }

        [ContextMenu("Stop Sound")]
        private void StopSound()
        {
            if (m_audioSource == null)
                return;
            if (m_secondPlayingCountSeconds <= 0f)
            {
                m_audioSource.Stop();
                m_secondPlayingCountSeconds = 0f;
            }
        }
    }

}