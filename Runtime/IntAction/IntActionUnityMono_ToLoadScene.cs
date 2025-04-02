using UnityEngine;

namespace Eloi.IntAction
{
    public class IntActionUnityMono_ToLoadScene : MonoBehaviour , I_IntActionBroadcastListener
    {
        public IntActionId m_reloadCurrentScene = new IntActionId(0);
        public IntToSceneIndexSet[] m_sceneIndexSet;
        public IntToSceneNameSet[] m_sceneNameSet= new IntToSceneNameSet[] { 
            new IntToSceneNameSet(101,"StartGameLobby"),
            new IntToSceneNameSet(201,"EndGameLobby"),
            new IntToSceneNameSet(301,"PlayerSelectionLobby")
        };


        public void HandleBroadcastedInteger(int integerValue)
        {
            for (int i = 0; i < m_sceneIndexSet.Length; i++)
            {
                if (m_sceneIndexSet[i].m_integer == integerValue)
                {
                    try { 
                        Debug.Log("Load Scene: " + m_sceneIndexSet[i].m_sceneIndex);
                        UnityEngine.SceneManagement.SceneManager.LoadScene(m_sceneIndexSet[i].m_sceneIndex);
                    }catch (System.Exception e)
                    {
                        Debug.LogError("Error: " + e.Message);
                    }
                    return;
                }
            }
            for (int i = 0; i < m_sceneNameSet.Length; i++)
            {
                if (m_sceneNameSet[i].m_integer == integerValue)
                {
                    try {

                        Debug.Log("Load Scene: " + m_sceneNameSet[i].m_sceneName);
                        UnityEngine.SceneManagement.SceneManager.LoadScene(m_sceneNameSet[i].m_sceneName);
                    }
                    catch (System.Exception e)
                    {
                        Debug.LogError("Error: " + e.Message);
                    }
                    return;
                }
            }
        }
    }
   
}