using CIRC.Core.Controllers;
using CIRC.Core.MiniGames.Core;
using CIRC.Core.Progression.Core;

namespace CIRC.Core.MiniGames.Sample.GoToSwim
{
    public class GoToSwim : MiniGame<GoToSwimContext>
    {
        public override void Begin(ref GoToSwimContext context)
        {
        }

        public override bool Refresh(ref GoToSwimContext context)
        {
            return context.isArrived;
        }

        public override void End(ref GoToSwimContext context, bool isSuccess)
        {
            if (isSuccess)
            {
                context.miniGameData.SaveElement.IsComplete = true;
                GameController.SaveData.SetPlayerCompleted(context.miniGameData.SaveElement);
                GameController.SavePlayerProgressToPlayerPrefs();
            }
            
            GameController.SceneController.LoadScene(GameController.Metrics.PlageScene);
        }
    }
}