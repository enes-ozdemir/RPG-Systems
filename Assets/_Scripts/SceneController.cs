using System;
using UnityEngine.SceneManagement;

namespace _Scripts
{
    public static class SceneController 
    {
        public static Action<int> onNewSceneLoaded;
        
        public static void LoadScene(int sceneIndex)
        {
            SceneManager.LoadScene(sceneIndex);
            onNewSceneLoaded?.Invoke(sceneIndex);
        }

    }
}