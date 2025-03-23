
using CIRC.Controllers;
using CIRC.MiniGames.Core;

namespace CIRC.MiniGames.Sample
{
    public class ProgrammesVilleTaper : MiniGame<ProgrammesVilleTaperContext>
    {
        public override void Begin(ref ProgrammesVilleTaperContext context)
        {
        }

        public override bool Refresh(ref ProgrammesVilleTaperContext context)
        {
            return context.isPlaced;
        }

        public override void End(ref ProgrammesVilleTaperContext context, bool isSuccess)
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