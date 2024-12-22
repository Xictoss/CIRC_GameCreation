using CIRC.Core.Controllers;
using CIRC.Core.MiniGames.Core;
using CIRC.Core.Progression.Core;

namespace CIRC.Core.MiniGames.Sample.AlcoolMaisonFrigo
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
                SaveManager.Instance.MarkMiniGameCompleted(
                    context.MiniGameData.MiniGameId,
                    context.MiniGameData.BadgeDisplay,
                    context.MiniGameData.GameSubject
                );
                SaveManager.Instance.SaveData();
            }

            GameController.SceneController.LoadScene(GameController.Metrics.PlageScene);
        }
    }
}