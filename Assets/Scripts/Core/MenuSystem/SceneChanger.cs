using CIRC.Core.Controllers;
using NaughtyAttributes;
using UnityEngine;

namespace CIRC.Core.MenuSystem
{
    public class SceneChanger : MonoBehaviour
    {
        [SerializeField, Scene] private int sceneIndex;

        public void ChangeScene()
        {
            GameController.SceneController.LoadScene(sceneIndex);
        }
    }
}