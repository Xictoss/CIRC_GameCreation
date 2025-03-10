
using CIRC.Controllers;
using CIRC.MiniGames.Core;

namespace CIRC.MiniGames.Sample
{
    public class AlcoolEntrepriseTaper : MiniGame<AlcoolEntrepriseTaperContext>
    {
        public override void Begin(ref AlcoolEntrepriseTaperContext context)
        {
        }

        public override bool Refresh(ref AlcoolEntrepriseTaperContext context)
        {
            return context.isRight;
        }

        public override void End(ref AlcoolEntrepriseTaperContext context, bool isSuccess)
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