using CIRC.Controllers;
using CIRC.MiniGames.Core;

namespace CIRC.MiniGames.Sample
{
    public class BookDrop : MiniGame<BookDropContext>
    {
        public override void Begin(ref BookDropContext context)
        {
        }

        public override bool Refresh(ref BookDropContext context)
        {
            return context.isArrived;
        }

        public override void End(ref BookDropContext context, bool isSuccess)
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