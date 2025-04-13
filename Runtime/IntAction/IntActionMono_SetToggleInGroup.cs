using UnityEngine;

namespace Eloi.IntAction
{


    public class IntActionMono_SetToggleInGroup : MonoBehaviour,  I_ContainsTogglePairOfIntegerActionId{

        public IntActionId m_actionOnTrueStart = 1000;
        public IntActionId m_actionOnFalseStart = 2000;

        public IntLobbyActionMono_Toggle[] m_toggleToSet;


        [ContextMenu("Turn them all On")]
        public void TurnOnAndPushIntegerForAll()
        {
            foreach (var toggle in m_toggleToSet)
            {
                toggle.TurnOnAndPushInteger();
            }
        }

        [ContextMenu("Turn them all off")]
        public void TurnOffAndPushIntegerForAll()
        {
            foreach (var toggle in m_toggleToSet)
            {
                toggle.TurnOffAndPushInteger();
            }
        }
        [ContextMenu("Set as random all")]
        public void TurnRandomlyAllToggles()
        {
            foreach (var toggle in m_toggleToSet)
            {
                bool isOn = Random.Range(0, 2) == 0;
                if (isOn)
                {
                    toggle.TurnOnAndPushInteger();
                }
                else
                {
                    toggle.TurnOffAndPushInteger();
                }
            }
        }



        public void GetIntActionIdTrue(out IntActionId integerActionId)
        {
            integerActionId = m_actionOnTrueStart;
        }

        public void GetIntActionIdFalse(out IntActionId integerActionId)
        {
            integerActionId = m_actionOnFalseStart;
        }

        public void SetIntActionIdTrue(IntActionId integerActionId)
        {
            m_actionOnTrueStart.SetWithInteger(integerActionId);
            int count = 0;
            foreach (var toggle in m_toggleToSet)
            {
                toggle.SetIntActionIdTrue(integerActionId + count);
                count++;
            }
        }

        public void SetIntActionIdFalse(IntActionId integerActionId)
        {
            m_actionOnFalseStart.SetWithInteger(integerActionId);
            int count = 0;
            foreach (var toggle in m_toggleToSet)
            {
                toggle.SetIntActionIdFalse(integerActionId + count);
                count++;
            }
        }

        public void SetIntActionIdTrue(int integerActionId)
        {
          
            SetIntActionIdTrue(new IntActionId(integerActionId));   
        }

        public void SetIntActionIdFalse(int integerActionId)
        {
            SetIntActionIdFalse(new IntActionId(integerActionId));
        }
    }
}