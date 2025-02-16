using CIRC.MenuSystem;
using CIRC.Progression;
using CIRC.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CIRC.Controllers
{
    public class MiniGameRegister : ILoadScene
    {
        public static MiniGameRegister Global => GameController.MiniGameRegister;

        public MiniGameDataHolder currentMiniGame { get; private set; }
        public bool WasCompleted { get; private set; }

        public void SetCurrentMiniGame(MiniGameDataHolder data)
        {
            currentMiniGame = data;
            WasCompleted = GameController.ProgressionManager.miniGameStatus[data.GUID];
        }
        
        public void OnSceneLoaded(string previousScene, Scene currentScene)
        {
            if (!previousScene.StartsWith("Assets/Scenes/MainScenes/MiniGames")) return;
            if (WasCompleted) return;
            
            bool success = MenuManager.Instance.TryOpenMenu(GameMetrics.Global.MiniGameReward, new MenuContext()
            {
                title = currentMiniGame.miniGameName,
                desc = currentMiniGame.miniGameDesc,
            });
        }
    }
}