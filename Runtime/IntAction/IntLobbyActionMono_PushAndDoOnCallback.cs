using System;
using UnityEngine;

namespace Eloi.IntAction
{
    public class IntLobbyActionMono_PushAndDoOnCallback : MonoBehaviour, I_IntegerListenAndEmitter, I_ContainsOneIntegerActionId
    {
        public IntLobbyAction_PushAndDoOnCallback m_pushAndDoCallback;

        public void AddEmissionListener(Action<int> listener)
        {
            m_pushAndDoCallback.AddEmissionListener(listener);
        }

        public void GetIntActionId(out IntActionId integerActionId)
        {
            m_pushAndDoCallback.GetIntActionId(out integerActionId);
        }

        public void HandleIntegerAction(int integerValue)
        {
            if (m_pushAndDoCallback == null) return;
            m_pushAndDoCallback.HandleIntegerAction(integerValue);
        }

        public void RemoveEmissionListener(Action<int> listener)
        {
            m_pushAndDoCallback.RemoveEmissionListener(listener);
        }

        [ContextMenu("Push The Waiting Integer")]
        public void PushTheWaitingInteger() {

            if (m_pushAndDoCallback == null) return;
            m_pushAndDoCallback.PushTheWaitingInteger();
        }
       
        public void SetIntActionId(IntActionId integerActionId)
        {
            m_pushAndDoCallback.SetIntActionId(integerActionId);
        }

        public void SetIntActionId(int integerActionId)
        {
            m_pushAndDoCallback.SetIntActionId(integerActionId);
        }
        
    }
}