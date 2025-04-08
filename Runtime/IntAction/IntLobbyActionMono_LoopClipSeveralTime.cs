using UnityEngine;

namespace Eloi.IntAction
{
    public class IntLobbyActionMono_LoopClipSeveralTime : AbstractIntegerListenAndEmitterMono
    {

        public AudioSource m_audioSource;

        public IntActionId m_triggerId= new IntActionId(7);
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


       
        protected override void ChildrenHandlerForIntegerAction(int integerValue)
        {
            if (m_triggerId.m_intActionValue == integerValue)
            {
                PlayGandalfSax();
            }
        }

        [ContextMenu("Play Gandalf Sax")]
        public void PlayGandalfSax()
        {
            if (m_audioSource == null)
                return;
            m_audioSource.Play();
            m_secondPlayingCountSeconds = m_audioSource.clip.length * m_loopCount;
        }

        [ContextMenu("Emit GandAlf Sax Event")]
        public void EmitGandalfSaxEvent()
        {

            base.SendInteger(m_loopCount);
        }

        private void Update()
        {
            if(m_secondPlayingCountSeconds > 0f)
            {
                m_secondPlayingCountSeconds -= Time.deltaTime;
                StopGandalf();
            }
        }

        private void StopGandalf()
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