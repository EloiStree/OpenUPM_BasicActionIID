namespace Eloi.IntAction
{
    [System.Serializable]
    public class IntToSceneIndexSet
    {
        public string m_description;
        public int m_integer;
        public int m_sceneIndex;
        public IntToSceneIndexSet(int integer, int sceneIndex,string description="")
        {
            m_integer = integer;
            m_sceneIndex = sceneIndex;
            m_description = description;
        }
    }
}