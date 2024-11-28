using UnityEngine.SceneManagement;

namespace CIRC.Core.Controllers
{
    public class SceneController
    {
        public SceneController Global => GameController.SceneController;
        
        public void LoadScene(int sceneIndex)
        {
            SceneManager.LoadScene(sceneIndex);
        }
    }
}