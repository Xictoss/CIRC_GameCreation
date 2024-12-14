using CIRC.Core.Controllers;
using CIRC.Core.MiniGames.Core;

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
                context.MiniGameDataOld.SaveElement.IsComplete = true;
                GameController.SaveData.SetPlayerCompleted(context.MiniGameDataOld.SaveElement);
                GameController.SavePlayerProgressToPlayerPrefsOLD();
            }

            GameController.SceneController.LoadScene(GameController.Metrics.PlageScene);
        }
    }
}