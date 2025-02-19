
using CIRC.Controllers;
using CIRC.MiniGames.Core;

namespace CIRC.MiniGames.Sample
{
    public class ActiviteLotissementTaper : MiniGame<ActiviteLotissementTaperContext>
    {
        public override void Begin(ref ActiviteLotissementTaperContext context)
        {
        }

        public override bool Refresh(ref ActiviteLotissementTaperContext context)
        {
            return context.isArrived;
        }

        public override void End(ref ActiviteLotissementTaperContext context, bool isSuccess)
        {
            if (isSuccess)
            {
                GameController.ProgressionManager.CompleteMiniGame(context.miniGameData.GUID);
                GameController.SaveProgress();
            }

            GameController.SceneController.LoadScene(GameController.Metrics.PlageScene);
        }
    }
}