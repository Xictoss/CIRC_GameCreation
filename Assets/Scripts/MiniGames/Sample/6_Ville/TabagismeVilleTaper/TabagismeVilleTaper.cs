
using CIRC.Controllers;
using CIRC.MiniGames.Core;

namespace CIRC.MiniGames.Sample
{
    public class TabagismeVilleTaper : MiniGame<TabagismeVilleTaperContext>
    {
        public override void Begin(ref TabagismeVilleTaperContext context)
        {
        }

        public override bool Refresh(ref TabagismeVilleTaperContext context)
        {
            return context.isFall;
        }

        public override void End(ref TabagismeVilleTaperContext context, bool isSuccess)
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