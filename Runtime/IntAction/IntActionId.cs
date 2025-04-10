using System;
using UnityEngine;

namespace Eloi.IntAction
{
    /// <summary>
    /// This class is a simple way to notify that the integer is an id to trigger an action
    /// </summary>
    [System.Serializable]
    public class IntActionId
    {

        [Tooltip("Represent the integer to trigger the action")]
        public int m_intActionValue;

        public IntActionId(int intActionValue)
        {
            this.m_intActionValue = intActionValue;
        }
        public IntActionId()
        {
            this.m_intActionValue = 0;
        }

        //overloadd == operator
        public static bool operator ==(IntActionId a, IntActionId b)
        {
            return a.m_intActionValue == b.m_intActionValue;
        }
        public static bool operator ==(IntActionId a, int b)
        {
            return a.m_intActionValue == b;
        }
        public static bool operator ==(int a, IntActionId b)
        {
            return a == b.m_intActionValue;
        }

        public static bool operator !=(IntActionId a, IntActionId b)
        {
            return a.m_intActionValue != b.m_intActionValue;
        }
        public static bool operator !=(IntActionId a, int b)
        {
            return a.m_intActionValue != b;
        }
        public static bool operator !=(int a, IntActionId b)
        {
            return a != b.m_intActionValue;
        }


        public void SetWithRandomIntegerPositive()
        {
            m_intActionValue = UnityEngine.Random.Range(1, int.MaxValue);
        }
        public void SetWithRandomIntegerNegative()
        {
            m_intActionValue = UnityEngine.Random.Range(int.MinValue, -1);

        }
        public void SetWithRandomInteger()
        {

            m_intActionValue = UnityEngine.Random.Range(int.MinValue, int.MaxValue);
        }
        public void SetWithRandom99999999()
        {
            m_intActionValue = UnityEngine.Random.Range(1, 99999999);
        }

        public void GetIntegerValue(out int integerStoreValue) { integerStoreValue = m_intActionValue; }
        public int GetIntegerValue() { return m_intActionValue; }
    }
}