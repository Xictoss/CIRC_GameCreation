using CIRC.Core.Controllers;
using CIRC.Core.MiniGames.Core;
using CIRC.Core.Progression.Core;

namespace CIRC.Core.MiniGames.Sample.AlcoolMaisonGlisser
{
    public class AlcoolMaisonGlisser : MiniGame<AlcoolMaisonGlisserContext>
    {
        public override void Begin(ref AlcoolMaisonGlisserContext context)
        {
        }

        public override bool Refresh(ref AlcoolMaisonGlisserContext context)
        {
            return false;
        }

        public override void End(ref AlcoolMaisonGlisserContext context, bool isSuccess)
        {
            if (isSuccess)
            {
                GameController.ProgressionManager.CompleteMiniGame(context.MiniGameData.GUID);
                GameController.SaveProgress();
            }

            GameController.SceneController.LoadScene(GameController.Metrics.PlageScene);
        }
    }
}