
using CIRC.Controllers;
using CIRC.MiniGames.Core;

namespace CIRC.MiniGames.Sample
{
    public class TabagismePlageCigarette : MiniGame<TabagismePlageCigaretteContext>
    {
        public override void Begin(ref TabagismePlageCigaretteContext context)
        {
        }

        public override bool Refresh(ref TabagismePlageCigaretteContext context)
        {
            return context.isDone;
        }

        public override void End(ref TabagismePlageCigaretteContext context, bool isSuccess)
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