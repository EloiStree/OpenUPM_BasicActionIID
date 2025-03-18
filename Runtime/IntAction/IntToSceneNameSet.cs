namespace Eloi.IntAction
{
    [System.Serializable]
    public class IntToSceneNameSet
    {
        public string m_description;
        public int m_integer;
        public string m_sceneName;
        public IntToSceneNameSet(int integer, string sceneName, string description="")
        {
            m_integer = integer;
            m_sceneName = sceneName;
            m_description = description;
        }
    }
}