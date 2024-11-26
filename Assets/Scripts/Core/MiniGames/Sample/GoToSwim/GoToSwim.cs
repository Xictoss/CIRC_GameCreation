using CIRC.Core.MiniGames.Core;
using CIRC.Core.MiniGames.Sample.RunAndDrink;

namespace CIRC.Core.MiniGames.Sample.GoToSwim
{
    public class GoToSwim : MiniGame<GoToSwimContext>
    {
        public override void Begin(ref GoToSwimContext context)
        {
        }

        public override bool Refresh(ref GoToSwimContext context)
        {
            return context.isArrived;
        }

        public override void End(ref GoToSwimContext context, bool isSuccess)
        {
            if (isSuccess)
            {
                context.miniGameData.ScriptableSaveElement.IsComplete = true;
                context.miniGameData.MiniGameBadge.ScriptableSaveElement.IsComplete = true;
                GameController.SavePlayerProgressToPlayerPrefs();
            }
            GameController.SceneController.LoadScene(GameController.Metrics.PlageScene);
        }
    }
}