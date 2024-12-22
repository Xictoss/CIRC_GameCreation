using CIRC.Core.Controllers;
using CIRC.Core.MiniGames.Core;
using CIRC.Core.Progression.Core;

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