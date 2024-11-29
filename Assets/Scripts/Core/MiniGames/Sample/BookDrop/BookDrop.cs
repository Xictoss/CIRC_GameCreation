using CIRC.Core.Controllers;
using CIRC.Core.MiniGames.Core;

namespace CIRC.Core.MiniGames.Sample.BookDrop
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
                context.miniGameData.saveElement.isComplete = true;
                context.miniGameData.badge.saveElement.isComplete = true;
                GameController.SavePlayerProgressToPlayerPrefs();
            }

            GameController.SceneController.LoadScene(GameController.Metrics.PlageScene);
        }
    }
}