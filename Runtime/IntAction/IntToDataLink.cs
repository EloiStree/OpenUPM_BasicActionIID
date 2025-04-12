using System;

namespace Eloi.IntAction
{
    [System.Serializable]
    public class IntToDataLink<T>
    {
        [UnityEngine.SerializeField] IntActionId m_integer;
        [UnityEngine.SerializeField] public T m_linkData;
        public IntToDataLink(int integer, T valueToSet)
        {
            m_integer = new IntActionId(integer);
            m_linkData = valueToSet;
        }
        public IntToDataLink(IntActionId integer, T valueToSet)
        {
            m_integer = integer;
            m_linkData = valueToSet;
        }
        public IntToDataLink()
        {
            m_integer = new IntActionId();
            m_linkData = default;
        }

        public void GetIngeter(out IntActionId integer)
        {
            integer = m_integer;
        }
        public void GetIngeter(out int integer)
        {
            integer = m_integer.Value;
        }

        public void SetIngeter(int integer)
        {
            m_integer.Value = integer;
        }
        public void SetIngeter(IntActionId integer)
        {
            m_integer = integer;
        }

        public void SetLinkedData(T valueToSet)
        {
            m_linkData = valueToSet;
        }
        public T GetLinkedData()
        {
            return m_linkData;
        }
        public void GetLinkedData(out T value)
        {
            value = m_linkData;
        }

        public int GetInteger()
        {
            return m_integer.Value;
        }

        public void GetInteger(out int integer)
        {
            integer = m_integer.Value;
        }
    }

}