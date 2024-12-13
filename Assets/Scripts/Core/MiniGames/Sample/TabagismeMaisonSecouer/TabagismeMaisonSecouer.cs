using CIRC.Core.Controllers;
using CIRC.Core.MiniGames.Core;

namespace CIRC.Core.MiniGames.Sample.TabagismeMaisonSecouer
{
    public class TabagismeMaisonSecouer : MiniGame<TabagismeMaisonSecouerContext>
    {
        public override void Begin(ref TabagismeMaisonSecouerContext context)
        {
        }

        public override bool Refresh(ref TabagismeMaisonSecouerContext context)
        {
            return false;
        }

        public override void End(ref TabagismeMaisonSecouerContext context, bool isSuccess)
        {
            if (isSuccess)
            {
                context.miniGameData.SaveElement.IsComplete = true;
                GameController.SaveData.SetPlayerCompleted(context.miniGameData.SaveElement);
                GameController.SavePlayerProgressToPlayerPrefs();
            }

            GameController.SceneController.LoadScene(GameController.Metrics.PlageScene);
        }
    }
}