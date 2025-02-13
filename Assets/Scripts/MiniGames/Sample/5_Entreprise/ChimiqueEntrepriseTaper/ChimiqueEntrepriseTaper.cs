
using CIRC.Controllers;
using CIRC.MiniGames.Core;

namespace CIRC.MiniGames.Sample
{
    public class ChimiqueEntrepriseTaper : MiniGame<ChimiqueEntrepriseTaperContext>
    {
        public override void Begin(ref ChimiqueEntrepriseTaperContext context)
        {
        }

        public override bool Refresh(ref ChimiqueEntrepriseTaperContext context)
        {
            for (int i = 0; i < context.holes.Length; i++)
            {
                if (!context.holes[i].IsArrived) return false;
            }

            return true;
        }

        public override void End(ref ChimiqueEntrepriseTaperContext context, bool isSuccess)
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