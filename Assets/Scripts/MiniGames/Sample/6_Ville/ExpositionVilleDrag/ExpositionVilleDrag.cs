
using CIRC.Controllers;
using CIRC.MiniGames.Core;

namespace CIRC.MiniGames.Sample
{
    public class ExpositionVilleDrag : MiniGame<ExpositionVilleDragContext>
    {
        public override void Begin(ref ExpositionVilleDragContext context)
        {
        }

        public override bool Refresh(ref ExpositionVilleDragContext context)
        {
            return context.isFinished;
        }

        public override void End(ref ExpositionVilleDragContext context, bool isSuccess)
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