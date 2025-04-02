using UnityEngine;
using UnityEngine.Events;

namespace Eloi.IntAction
{
    public class IntActionMono_OneConditionHolderSet : DefaultIntegerEmitterEventMono {
       
        public bool m_conditionReached = false;
        public IntActionId m_conditionCompleted;
      
        [ContextMenu("Notify as condition reach")]
        public void NotifyConditionReach() {
            if (!m_conditionReached)
            {
                m_conditionReached = true;
                SendInteger(m_conditionCompleted);
            }
        }
        [ContextMenu("Choose random Integer ID")]
        void ChooseRandomIntegerNumber() {

            m_conditionCompleted.SetWithRandom99999999();
        }
    }


}