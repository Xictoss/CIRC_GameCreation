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