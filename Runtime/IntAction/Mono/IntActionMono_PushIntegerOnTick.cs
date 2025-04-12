using UnityEngine;

namespace Eloi.IntAction
{
    public class IntActionMono_PushIntegerOnTick : DefaultIntegerEmitterEventMono {

        public int m_integerToPushOnTick;

        [ContextMenu("Tick Invoke")]
        public void TickInvoke()
        {
            m_onIntegerActionEmitted.Invoke(m_integerToPushOnTick);
        }
    }

}