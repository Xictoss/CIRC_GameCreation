using NaughtyAttributes;
using UnityEngine;

namespace CIRC.Core.MenuSystem
{
    public class SceneChanger : MonoBehaviour
    {
        [Scene]
        [SerializeField] private int sceneIndex;

        public void ChangeScene()
        {
            GameController.SceneController.LoadScene(sceneIndex);
        }
    }
}