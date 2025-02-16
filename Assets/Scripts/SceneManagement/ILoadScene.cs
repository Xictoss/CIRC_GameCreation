using UnityEngine.SceneManagement;

namespace CIRC.SceneManagement
{
    public interface ILoadScene
    {
        public void OnSceneLoaded(string previousScene, Scene currentScene);
    }
}