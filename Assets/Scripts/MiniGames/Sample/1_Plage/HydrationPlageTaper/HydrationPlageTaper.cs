
using CIRC.Controllers;
using CIRC.MiniGames.Core;

namespace CIRC.MiniGames.Sample
{
    public class HydrationPlageTaper : MiniGame<HydrationPlageTaperContext>
    {
        public override void Begin(ref HydrationPlageTaperContext context)
        {
        }

        public override bool Refresh(ref HydrationPlageTaperContext context)
        {
            return context.isFinished;
        }

        public override void End(ref HydrationPlageTaperContext context, bool isSuccess)
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