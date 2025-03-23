
using CIRC.Controllers;
using CIRC.MiniGames.Core;

namespace CIRC.MiniGames.Sample
{
    public class ActiviteVilleTaper : MiniGame<ActiviteVilleTaperContext>
    {
        public override void Begin(ref ActiviteVilleTaperContext context)
        {
        }

        public override bool Refresh(ref ActiviteVilleTaperContext context)
        {
            return context.isArrived;
        }

        public override void End(ref ActiviteVilleTaperContext context, bool isSuccess)
        {
            if (isSuccess)
            {
                GameController.ProgressionManager.CompleteMiniGame(context.miniGameData.GUID);
                GameController.SaveProgress();
            }

            GameController.SceneController.LoadScene(GameController.Metrics.VilleScene);
        }
    }
}