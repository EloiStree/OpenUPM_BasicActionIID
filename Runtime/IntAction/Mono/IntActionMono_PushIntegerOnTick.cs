using UnityEngine;

namespace Eloi.IntAction
{
    public class IntActionMono_PushIntegerOnTick : DefaultIntegerEmitterEventMono , I_ContainsOneIntegerActionId
    {

        public IntActionId m_integerToPushOnTick;

        public void GetIntActionId(out IntActionId integerActionId)
        {
            integerActionId= m_integerToPushOnTick;
        }

        public void SetIntActionId(IntActionId integerActionId)
        {
            m_integerToPushOnTick = integerActionId;

        }

        public void SetIntActionId(int integerActionId)
        {
            m_integerToPushOnTick.SetWithInteger(integerActionId);
        }

        [ContextMenu("Tick Invoke")]
        public void TickInvoke()
        {
            m_onIntegerActionEmitted.Invoke(m_integerToPushOnTick.Value);
        }
    }

}