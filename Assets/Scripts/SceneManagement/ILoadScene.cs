using UnityEngine.SceneManagement;

namespace CIRC.SceneManagement
{
    public interface ILoadScene
    {
        public void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode);
    }
}