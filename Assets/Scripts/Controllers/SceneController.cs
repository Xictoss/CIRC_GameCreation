using UnityEngine.SceneManagement;

namespace CIRC.Controllers
{
    public class SceneController
    {
        public SceneController Global => GameController.SceneController;

        public string previousScene { get; private set; } 
        
        public void LoadScene(int sceneIndex)
        {
            previousScene = SceneManager.GetActiveScene().path;
            SceneManager.LoadScene(sceneIndex);
        }
    }
}