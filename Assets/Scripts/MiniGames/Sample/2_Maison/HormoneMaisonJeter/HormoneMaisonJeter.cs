using CIRC.Controllers;
using CIRC.MiniGames.Core;

namespace CIRC.MiniGames.Sample
{
    public class HormoneMaisonJeter : MiniGame<HormoneMaisonJeterContext>
    {
        public override void Begin(ref HormoneMaisonJeterContext context)
        {
        }

        public override bool Refresh(ref HormoneMaisonJeterContext context)
        {
            return context.pillsManager.IsDone;
        }

        public override void End(ref HormoneMaisonJeterContext context, bool isSuccess)
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