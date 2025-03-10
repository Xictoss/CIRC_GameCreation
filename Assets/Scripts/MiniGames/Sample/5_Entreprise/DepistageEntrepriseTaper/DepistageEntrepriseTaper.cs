
using CIRC.Controllers;
using CIRC.MiniGames.Core;

namespace CIRC.MiniGames.Sample
{
    public class DepistageEntrepriseTaper : MiniGame<DepistageEntrepriseTaperContext>
    {
        public override void Begin(ref DepistageEntrepriseTaperContext context)
        {
        }

        public override bool Refresh(ref DepistageEntrepriseTaperContext context)
        {
            return context.isRight;
        }

        public override void End(ref DepistageEntrepriseTaperContext context, bool isSuccess)
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