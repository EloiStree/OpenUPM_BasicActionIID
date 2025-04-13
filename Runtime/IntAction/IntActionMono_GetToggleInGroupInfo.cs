using UnityEngine;

namespace Eloi.IntAction
{
    public class IntActionMono_GetToggleInGroupInfo : MonoBehaviour
    {
        public IntAction_GetToggleInGroupInfo m_observedGroup;

        public void IsAllTrue(out bool isAllTrue) {

            m_observedGroup.IsAllTrue(out isAllTrue);
        }
        public void IsAllFalse(out bool isAllFalse)
        {
            m_observedGroup.IsAllFalse(out isAllFalse);
        }

        public void IsOneTrue(out bool isOneTrue)
        {
            m_observedGroup.IsOneTrue(out isOneTrue);
        }
        public void IsOneFalse(out bool isOneFalse)
        {
            m_observedGroup.IsOneFalse(out isOneFalse);
        }


    }
}