using System;
using UnityEngine;

namespace Eloi.IntAction
{

    // Let create a scriptable with two SCRITABLE_IntActionId
    [CreateAssetMenu(fileName = "IntActionIdPair", menuName = "IntAction/IntActionIdPair", order = 1)]
    public class SCRIPTABLE_IntActionIdPairOnOff : ScriptableObject
    {
        [TextArea(0, 3)]
        [Tooltip("This is a reminder to help you to remember what this integer is used for")]
        public string m_intActionDescription = string.Empty;
        [Tooltip("Represent the integer to trigger the action")]
        [SerializeField] SCRIPTABLE_IntActionId m_intActionValueOn;
        [SerializeField] SCRIPTABLE_IntActionId m_intActionValueOff;
        public int OnValue
        {
            get { return m_intActionValueOn.Value; }
            set { m_intActionValueOn.Value = value; }
        }
        public int OffValue
        {
            get { return m_intActionValueOff.Value; }
            set { m_intActionValueOff.Value = value; }
        }
    }


    // Let create a scriptable object of IntActionId
    [CreateAssetMenu(fileName = "IntActionId", menuName = "IntAction/IntActionId", order = 1)]
    public class SCRIPTABLE_IntActionId : ScriptableObject
    {
        [TextArea(0,3)]
        [Tooltip("This is a reminder to help you to remember what this integer is used for")]
        public string m_intActionDescription= string.Empty;
        [Tooltip("Represent the integer to trigger the action")]
        [SerializeField] IntActionId m_intActionValue;
        public int Value
        {
            get { return m_intActionValue.Value; }
            set { m_intActionValue.Value = value; }
        }
        public void GetShortDescription(out string shortDescription)
        {
            shortDescription = m_intActionDescription;
        }
        public void SetShortDescription(string shortDescription)
        {
            m_intActionDescription = shortDescription;
        }

        public void SetWithInteger(int integerValue)
        {
            m_intActionValue.SetWithInteger(integerValue);
        }
        public void GetInteger(out int integerStoreValue)
        {
            m_intActionValue.GetIntegerValue(out integerStoreValue);
        }
        public int GetIntegerValue()
        {
            return m_intActionValue.GetIntegerValue();
        }
       
    }


    /// <summary>
    /// This class is a simple way to notify that the integer is an id to trigger an action
    /// </summary>
    [System.Serializable]
    public class IntActionId
    {

        [Tooltip("Represent the integer to trigger the action")]
        [SerializeField] int m_intActionValue;

        public IntActionId(int intActionValue)
        {
            this.Value = intActionValue;
        }
        public IntActionId()
        {
            this.Value = 0;
        }

        //overloadd == operator
        public static bool operator ==(IntActionId a, IntActionId b)
        {
            return a.Value == b.Value;
        }
        public static bool operator ==(IntActionId a, int b)
        {
            return a.Value == b;
        }
        public static bool operator ==(int a, IntActionId b)
        {
            return a == b.Value;
        }

        public static bool operator !=(IntActionId a, IntActionId b)
        {
            return a.Value != b.Value;
        }
        public static bool operator !=(IntActionId a, int b)
        {
            return a.Value != b;
        }
        public static bool operator !=(int a, IntActionId b)
        {
            return a != b.Value;
        }

        public static implicit operator IntActionId(int v)
        {
            return new IntActionId(v);
        }
        public static implicit operator int(IntActionId v)
        {
            return v.Value;
        }
        

        public void SetWithInteger(int integerValue)
        {
            m_intActionValue = integerValue;
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


        public int Value
        {
            get { return m_intActionValue; }
            set { m_intActionValue = value; }
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}