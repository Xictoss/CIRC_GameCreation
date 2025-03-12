
using CIRC.Controllers;
using CIRC.MiniGames.Core;

namespace CIRC.MiniGames.Sample
{
    public class ZoneLotissementTaper : MiniGame<ZoneLotissementTaperContext>
    {
        public override void Begin(ref ZoneLotissementTaperContext context)
        {
        }

        public override bool Refresh(ref ZoneLotissementTaperContext context)
        {
            return context.Finished;
        }

        public override void End(ref ZoneLotissementTaperContext context, bool isSuccess)
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