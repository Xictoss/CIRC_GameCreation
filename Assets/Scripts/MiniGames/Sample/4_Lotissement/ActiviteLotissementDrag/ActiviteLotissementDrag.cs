
using CIRC.Controllers;
using CIRC.MiniGames.Core;

namespace CIRC.MiniGames.Sample
{
    public class ActiviteLotissementDrag : MiniGame<ActiviteLotissementDragContext>
    {
        public override void Begin(ref ActiviteLotissementDragContext context)
        {
        }

        public override bool Refresh(ref ActiviteLotissementDragContext context)
        {
            return context.isFinished;
        }

        public override void End(ref ActiviteLotissementDragContext context, bool isSuccess)
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