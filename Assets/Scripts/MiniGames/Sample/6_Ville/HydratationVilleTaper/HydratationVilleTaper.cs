
using CIRC.Controllers;
using CIRC.MiniGames.Core;

namespace CIRC.MiniGames.Sample
{
    public class HydratationVilleTaper : MiniGame<HydratationVilleTaperContext>
    {
        public override void Begin(ref HydratationVilleTaperContext context)
        {
        }

        public override bool Refresh(ref HydratationVilleTaperContext context)
        {
            return context.isRight;
        }

        public override void End(ref HydratationVilleTaperContext context, bool isSuccess)
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