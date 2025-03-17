
using CIRC.Controllers;
using CIRC.MiniGames.Core;

namespace CIRC.MiniGames.Sample
{
    public class AlimentationVilleGlisser : MiniGame<AlimentationVilleGlisserContext>
    {
        public override void Begin(ref AlimentationVilleGlisserContext context)
        {
        }

        public override bool Refresh(ref AlimentationVilleGlisserContext context)
        {
            return context.isPlaced;
        }

        public override void End(ref AlimentationVilleGlisserContext context, bool isSuccess)
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