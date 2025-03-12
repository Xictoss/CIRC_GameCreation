
using CIRC.Controllers;
using CIRC.MiniGames.Core;

namespace CIRC.MiniGames.Sample
{
    public class AlimentationPlageChips : MiniGame<AlimentationPlageChipsContext>
    {
        public override void Begin(ref AlimentationPlageChipsContext context)
        {
        }

        public override bool Refresh(ref AlimentationPlageChipsContext context)
        {
            return context.isFinish;
        }

        public override void End(ref AlimentationPlageChipsContext context, bool isSuccess)
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