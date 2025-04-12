using UnityEngine;

namespace Eloi.IntAction
{
    public class UnityMono_LoadGivenScene : MonoBehaviour 
    {
        public void LoadSceneFromName(string sceneName)
        {
            try
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
            }
            catch (System.Exception e)
            {
                Debug.LogError("Error: " + e.Message);
            }
        }
        public void LoadSceneFromIndex(int sceneIndex)
        {
            try
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(sceneIndex);
            }
            catch (System.Exception e)
            {
                Debug.LogError("Error: " + e.Message);
            }
        }
        public void ReloadCurrentScene()
        {
            try
            {
                int currentSceneIndex = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
                UnityEngine.SceneManagement.SceneManager.LoadScene(currentSceneIndex);
            }
            catch (System.Exception e)
            {
                Debug.LogError("Error: " + e.Message);
            }
        }
    }
   
}