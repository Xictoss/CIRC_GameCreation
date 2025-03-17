
using CIRC.Controllers;
using CIRC.MiniGames.Core;

namespace CIRC.MiniGames.Sample
{
    public class HydratationCliniqueDrag : MiniGame<HydratationCliniqueDragContext>
    {
        public override void Begin(ref HydratationCliniqueDragContext context)
        {
        }

        public override bool Refresh(ref HydratationCliniqueDragContext context)
        {
            return context.isRight;
        }

        public override void End(ref HydratationCliniqueDragContext context, bool isSuccess)
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