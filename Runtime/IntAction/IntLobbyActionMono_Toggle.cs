using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Eloi.IntAction
{

    

    public class IntLobbyActionMono_Toggle : MonoBehaviour, I_IntegerListenAndEmitter, I_ContainsTogglePairOfIntegerActionId
    {
        
        [SerializeField] IntLobbyAction_Toggle m_toggle= new IntLobbyAction_Toggle();
        public void SetOnOffAndPushInteger(bool isOn) => m_toggle?.SetOnOff(isOn, true);
        
        public void SetOnOff(bool isOn, bool pushInteger = false)
        {
            m_toggle?.SetOnOff(isOn, pushInteger);
        }

        public void SetIntegerWhenOn(int integerValue)
        {
            m_toggle?.SetIntegerIdWhenOn(integerValue);
        }
        public void SetIntegerWhenOff(int integerValue)
        {
            m_toggle?.SetIntegerIdWhenOff(integerValue);
        }

        [ContextMenu("Turn On and send integer")]
        public void TurnOnAndPushInteger() => m_toggle?.TurnOnAndPushInteger();

        [ContextMenu("Turn Off and send integer")]

        public void TurnOffAndPushInteger() => m_toggle?.TurnOffAndPushInteger();
        [ContextMenu("Switch and send integer")]

        public void SwitchOnOffAndPushInteger() => m_toggle?.SwitchOnOffAndPushInteger();




        [ContextMenu("Turn On and dont send integer")]
        public void TurnOnWithoutPushInteger() => m_toggle?.TurnOnWithoutPushInteger();

        [ContextMenu("Turn Off and dont send integer")]
        public void TurnOffWithoutPushInteger() => m_toggle?.TurnOffWithoutPushInteger();

        [ContextMenu("Switch Value without pushing")]
        public void SwitchOnOffWithoutPushInteger() => m_toggle?.SwitchOnOffWithoutPushInteger();




        public bool GetCurrentValue()
        {
            return m_toggle.GetCurrentValue();
        }
        public void GetCurrentValue(out bool value)
        {
            m_toggle.GetCurrentValue(out value);
        }

        public void HandleIntegerAction(int integerValue)
        {
            //if (IsObjectNotActive())return;
            m_toggle?.HandleIntegerAction(integerValue);
        }

        //private bool IsObjectNotActive()
        //{
        //    return !this.gameObject.activeInHierarchy || !this.enabled;
        //}
        //private bool IsObjectActive()
        //{
        //    return this.gameObject.activeInHierarchy && this.enabled;
        //}

        public void AddEmissionListener(Action<int> listener)
        {
            m_toggle?.AddEmissionListener(listener);
        }

        public void RemoveEmissionListener(Action<int> listener)
        {
            m_toggle?.RemoveEmissionListener(listener);
        }

        public void GetIntActionIdTrue(out IntActionId integerActionId)
        {
            integerActionId = m_toggle?.m_onIntegerId;
        }

        public void GetIntActionIdFalse(out IntActionId integerActionId)
        {
            integerActionId = m_toggle?.m_offIntegerId;
        }

        public void SetIntActionIdTrue(IntActionId integerActionId)
        {
            m_toggle?.SetIntegerIdWhenOn(integerActionId.Value);
        }

        public void SetIntActionIdFalse(IntActionId integerActionId)
        {
            m_toggle?.SetIntegerIdWhenOff(integerActionId.Value);
        }

        public void SetIntActionIdTrue(int integerActionId)
        {
            m_toggle?.SetIntegerIdWhenOn(integerActionId);
        }

        public void SetIntActionIdFalse(int integerActionId)
        {
            m_toggle?.SetIntegerIdWhenOff(integerActionId);
        }
    }
}