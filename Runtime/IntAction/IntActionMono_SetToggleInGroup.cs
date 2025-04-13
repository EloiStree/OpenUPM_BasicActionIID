using UnityEngine;
using UnityEngine.Events;

namespace Eloi.IntAction
{

    [System.Serializable]
    public class IntAction_GetToggleInGroupInfoUnity {

        public IntActionMono_GetToggleInGroupInfo m_observed;

        [Header("State")]
        public bool m_isAllTrue;
        public bool m_isAllFalse;
        public bool m_isOneTrue;
        public bool m_isOneFalse;

        [Header("On Value Changed")]
        public UnityEvent<bool> m_onIsAllTrueChanged;
        public UnityEvent<bool> m_onIsAllFalseChanged;
        public UnityEvent<bool> m_onIsOneTrueChanged;
        public UnityEvent<bool> m_onIsOneFalseChanged;

        [Header("On Check Update")]
        public UnityEvent<bool> m_onIsAllTrueUpdated;
        public UnityEvent<bool> m_onIsAllFalseUpdated;
        public UnityEvent<bool> m_onIsOneTrueUpdated;
        public UnityEvent<bool> m_onIsOneFalseUpdated;


        public void UpdateStateOfToggles() {

            bool isAllTrue = m_isAllTrue;
            bool isAllFalse = m_isAllFalse;
            bool isOneTrue = m_isOneTrue;
            bool isOneFalse = m_isOneFalse;

            m_observed.IsAllTrue(out m_isAllTrue);
            m_observed.IsAllFalse(out m_isAllFalse);
            m_observed.IsOneTrue(out m_isOneTrue);
            m_observed.IsOneFalse(out m_isOneFalse);

            m_onIsAllTrueUpdated?.Invoke(m_isAllTrue);
            m_onIsAllFalseUpdated?.Invoke(m_isAllFalse);
            m_onIsOneTrueUpdated?.Invoke(m_isOneTrue);
            m_onIsOneFalseUpdated?.Invoke(m_isOneFalse);

            if (isAllTrue != m_isAllTrue)
            {
                m_onIsAllTrueChanged?.Invoke(m_isAllTrue);
            }
            if (isAllFalse != m_isAllFalse)
            {
                m_onIsAllFalseChanged?.Invoke(m_isAllFalse);
            }
            if (isOneTrue != m_isOneTrue)
            {
                m_onIsOneTrueChanged?.Invoke(m_isOneTrue);
            }
            if (isOneFalse != m_isOneFalse)
            {
                m_onIsOneFalseChanged?.Invoke(m_isOneFalse);
            }

        }


    }

    [System.Serializable]
    public class IntAction_GetToggleInGroupInfo  {

        public IntLobbyActionMono_Toggle[] m_toggleToSet;

        public void IsAllTrue(out bool isAllTrue)
        {
            isAllTrue = true;
            foreach (var toggle in m_toggleToSet)
            {
                if (toggle != null && !toggle.GetCurrentValue())
                {
                    isAllTrue = false;
                    break;
                }
            }
        }

        public void IsAllFalse(out bool isAllFalse)
        {
            isAllFalse = true;
            foreach (var toggle in m_toggleToSet)
            {
                if (toggle != null && toggle.GetCurrentValue())
                {
                    isAllFalse = false;
                    break;
                }
            }
        }
        public void IsOneTrue(out bool isOneTrue)
        {
            isOneTrue = false;
            foreach (var toggle in m_toggleToSet)
            {
                if (toggle!=null && toggle.GetCurrentValue())
                {
                    isOneTrue = true;
                    break;
                }
            }
        }
        public void IsOneFalse(out bool isOneFalse)
        {
            isOneFalse = false;
            foreach (var toggle in m_toggleToSet)
            {
                if (toggle != null && !toggle.GetCurrentValue())
                {
                    isOneFalse = true;
                    break;
                }
            }
        }
    }

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