using UnityEngine;

namespace Eloi.IntAction
{
    /// <summary>
    /// This class is a simple way to notify that the integer is an id to trigger an action
    /// </summary>
    [System.Serializable]
    public class IntActionId {

        [Tooltip("Represent the integer to trigger the action")]
        public int m_intActionValue;

        public IntActionId(int intActionValue)
        {
            this.m_intActionValue = intActionValue;
        }
    }

    
}