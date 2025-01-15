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
                GameController.ProgressionManager.CompleteMiniGame(context.MiniGameData.GUID);
                GameController.SaveProgress();
            }
            
            GameController.SceneController.LoadScene(GameController.Metrics.PlageScene);
        }
    }
}