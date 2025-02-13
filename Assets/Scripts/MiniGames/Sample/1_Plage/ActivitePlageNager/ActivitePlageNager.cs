using CIRC.Controllers;
using CIRC.MiniGames.Core;

namespace CIRC.MiniGames.Sample
{
    public class ActivitePlageNager : MiniGame<ActivitePlageNagerContext>
    {
        public override void Begin(ref ActivitePlageNagerContext context)
        {
        }

        public override bool Refresh(ref ActivitePlageNagerContext context)
        {
            return context.isArrived;
        }

        public override void End(ref ActivitePlageNagerContext context, bool isSuccess)
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