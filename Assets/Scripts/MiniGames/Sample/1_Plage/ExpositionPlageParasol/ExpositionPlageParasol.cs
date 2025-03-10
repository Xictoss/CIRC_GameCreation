
using CIRC.Controllers;
using CIRC.MiniGames.Core;

namespace CIRC.MiniGames.Sample
{
    public class ExpositionPlageParasol : MiniGame<ExpositionPlageParasolContext>
    {
        public override void Begin(ref ExpositionPlageParasolContext context)
        {
        }

        public override bool Refresh(ref ExpositionPlageParasolContext context)
        {
            return context.isFinished;
        }

        public override void End(ref ExpositionPlageParasolContext context, bool isSuccess)
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