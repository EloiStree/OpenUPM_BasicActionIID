namespace Eloi.IntAction
{
    public class IntActionMono_IntToSingleUnityEvent : DefaultIntegerListenEventMono, I_ContainsOneIntegerActionId
    {
        public IntToSingleUnityEvent m_integetToTrigger;

        public void GetIntActionId(out IntActionId integerActionId)
        {
            integerActionId = new IntActionId(m_integetToTrigger.m_triggerValue);
        }

        public void SetIntActionId(IntActionId integerActionId)
        {
            m_integetToTrigger.m_triggerValue = integerActionId.Value;
        }

        public void SetIntActionId(int integerActionId)
        {
            m_integetToTrigger.m_triggerValue = integerActionId;

        }

        protected override void ChildrenHandlerForIntegerAction(int integerValue)
        {
            if (m_integetToTrigger != null &&
                m_integetToTrigger.m_triggerValue == integerValue)
            {
                m_integetToTrigger.m_onTriggered.Invoke();
            }
        }

    }

}