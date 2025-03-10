
using CIRC.Controllers;
using CIRC.MiniGames.Core;

namespace CIRC.MiniGames.Sample
{
    public class AlimentationEntrepriseTaper : MiniGame<AlimentationEntrepriseTaperContext>
    {
        public override void Begin(ref AlimentationEntrepriseTaperContext context)
        {
        }

        public override bool Refresh(ref AlimentationEntrepriseTaperContext context)
        {
            return context.isRight;
        }

        public override void End(ref AlimentationEntrepriseTaperContext context, bool isSuccess)
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