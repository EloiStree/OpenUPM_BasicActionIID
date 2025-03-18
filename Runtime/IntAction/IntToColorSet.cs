using UnityEngine;

namespace Eloi.IntAction
{
    [System.Serializable]
    public class IntToColorSet
    {
        public IntActionId m_integer;
        public Color m_colorValueToSet;
        public IntToColorSet(int integer, Color valueToSet)
        {
            m_integer = new IntActionId(integer);
            m_colorValueToSet = valueToSet;
        }
    }

}