using CIRC.MenuSystem;
using CIRC.Progression;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CIRC.Controllers
{
    public class MiniGameRegister
    {
        public static MiniGameRegister Global => GameController.MiniGameRegister;

        public MiniGameDataHolder currentMiniGame { get; private set; }
        public bool WasCompleted { get; private set; }

        public void SetCurrentMiniGame(MiniGameDataHolder data)
        {
            currentMiniGame = data;
            WasCompleted = GameController.ProgressionManager.miniGameStatus[data.GUID];
        }

        public void OnSceneChanged(Scene scene, LoadSceneMode loadSceneMode)
        {
            if (GameController.SceneController.previousScene == default) return;
            if (!GameController.SceneController.previousScene.StartsWith("Assets/Scenes/MainScenes/MiniGames")) return;
            if (WasCompleted) return;
            
            bool success = MenuManager.Instance.TryOpenMenu(GameMetrics.Global.MiniGameReward, new MenuContext()
            {
                title = currentMiniGame.miniGameName,
                desc = currentMiniGame.miniGameDesc,
            });
        }
    }
}