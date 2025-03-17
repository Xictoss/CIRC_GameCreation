
using CIRC.Controllers;
using CIRC.MiniGames.Core;

namespace CIRC.MiniGames.Sample
{
    public class TabagismeCliniqueTaper : MiniGame<TabagismeCliniqueTaperContext>
    {
        public override void Begin(ref TabagismeCliniqueTaperContext context)
        {
        }

        public override bool Refresh(ref TabagismeCliniqueTaperContext context)
        {
            return context.isRight;
        }

        public override void End(ref TabagismeCliniqueTaperContext context, bool isSuccess)
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