using UnityEngine;

namespace NomDuJeu.Core
{
    public static class SceneManager
    {
        public static void LoadScene(int sceneIndex)
        {
            Debug.Log("Load Scene" + sceneIndex);
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneIndex);
        }
    }
}