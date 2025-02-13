using CIRC.Controllers;
using CIRC.MiniGames.Core;

namespace CIRC.MiniGames.Sample
{
    public class AlcoolMaisonFrigo : MiniGame<AlcoolMaisonFrigoContext>
    {
        public override void Begin(ref AlcoolMaisonFrigoContext context)
        {
        }

        public override bool Refresh(ref AlcoolMaisonFrigoContext context)
        {
            return context.alcoolMaisonFrigoChoose.isFinished;
        }

        public override void End(ref AlcoolMaisonFrigoContext context, bool isSuccess)
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