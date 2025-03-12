
using CIRC.Controllers;
using CIRC.MiniGames.Core;

namespace CIRC.MiniGames.Sample
{
    public class HydratationPlageTourner : MiniGame<HydratationPlageTournerContext>
    {
        public override void Begin(ref HydratationPlageTournerContext context)
        {
        }

        public override bool Refresh(ref HydratationPlageTournerContext context)
        {
            return context.isFinished;
        }

        public override void End(ref HydratationPlageTournerContext context, bool isSuccess)
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