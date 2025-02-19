using CIRC.Controllers;
using CIRC.Progression;
using UnityEngine;

namespace CIRC.MenuSystem
{
    public class MiniGameStart : SceneChanger
    {
        [SerializeField] private MiniGameDataHolder data;
        
        public override void ChangeScene()
        {
            GameController.MiniGameRegister.SetCurrentMiniGame(data);
            GameController.SceneController.LoadScene(sceneIndex);
        }
    }
}