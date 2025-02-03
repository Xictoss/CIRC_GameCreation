using CIRC.Controllers;
using CIRC.MiniGames.Core;

namespace CIRC.MiniGames.Sample
{
    public class ActiviteMaisonTele : MiniGame<ActiviteMaisonTeleContext>
    {
        public override void Begin(ref ActiviteMaisonTeleContext context)
        {
        }

        public override bool Refresh(ref ActiviteMaisonTeleContext context)
        {
            return context.IsArrived;
        }

        public override void End(ref ActiviteMaisonTeleContext context, bool isSuccess)
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