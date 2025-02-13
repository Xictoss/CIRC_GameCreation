using UnityEngine.SceneManagement;

namespace CIRC.Controllers
{
    public class SceneController
    {
        public SceneController Global => GameController.SceneController;

        public Scene previousScene { get; private set; } 
        
        public void LoadScene(int sceneIndex)
        {
            previousScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(sceneIndex);
        }
    }
}