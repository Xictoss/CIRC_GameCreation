
using CIRC.Controllers;
using CIRC.MiniGames.Core;

namespace CIRC.MiniGames.Sample
{
    public class AlcoolMaisonBoisson : MiniGame<AlcoolMaisonBoissonContext>
    {
        public override void Begin(ref AlcoolMaisonBoissonContext context)
        {
        }

        public override bool Refresh(ref AlcoolMaisonBoissonContext context)
        {
            return context.glass.isArrived;
        }

        public override void End(ref AlcoolMaisonBoissonContext context, bool isSuccess)
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