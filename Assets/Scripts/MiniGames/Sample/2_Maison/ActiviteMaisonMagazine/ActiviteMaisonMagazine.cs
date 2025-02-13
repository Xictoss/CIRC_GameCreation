using CIRC.Controllers;
using CIRC.MiniGames.Core;

namespace CIRC.MiniGames.Sample
{
    public class ActiviteMaisonMagazine : MiniGame<ActiviteMaisonMagazineContext>
    {
        public override void Begin(ref ActiviteMaisonMagazineContext context)
        {
        }

        public override bool Refresh(ref ActiviteMaisonMagazineContext context)
        {
            return context.isArrived;
        }

        public override void End(ref ActiviteMaisonMagazineContext context, bool isSuccess)
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