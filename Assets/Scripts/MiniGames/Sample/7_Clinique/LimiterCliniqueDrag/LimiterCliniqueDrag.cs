
using CIRC.Controllers;
using CIRC.MiniGames.Core;

namespace CIRC.MiniGames.Sample
{
    public class LimiterCliniqueDrag : MiniGame<LimiterCliniqueDragContext>
    {
        public override void Begin(ref LimiterCliniqueDragContext context)
        {
        }

        public override bool Refresh(ref LimiterCliniqueDragContext context)
        {
            return context.isGood;
        }

        public override void End(ref LimiterCliniqueDragContext context, bool isSuccess)
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