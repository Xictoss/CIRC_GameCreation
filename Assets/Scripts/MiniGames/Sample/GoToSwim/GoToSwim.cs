using CIRC.Controllers;
using CIRC.MiniGames.Core;

namespace CIRC.MiniGames.Sample
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
                GameController.ProgressionManager.CompleteMiniGame(context.MiniGameData.GUID);
                GameController.SaveProgress();
            }
            
            GameController.SceneController.LoadScene(GameController.Metrics.PlageScene);
        }
    }
}