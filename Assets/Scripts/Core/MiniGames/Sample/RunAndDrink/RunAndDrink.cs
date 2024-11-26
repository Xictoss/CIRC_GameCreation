using System.Runtime.Remoting.Contexts;
using CIRC.Core.MiniGames.Core;
using CIRC.Core.MiniGames.Sample.SortAndSplodeMiniGame;

namespace CIRC.Core.MiniGames.Sample.RunAndDrink
{
    public class RunAndDrink : MiniGame<RunAndDrinkContext>
    {
        public override void Begin(ref RunAndDrinkContext context)
        {
        }

        public override bool Refresh(ref RunAndDrinkContext context)
        {
            
            return context.remainingDrinks <= 0;
            
        }

        public override void End(ref RunAndDrinkContext context, bool isSuccess)
        {
            if (isSuccess)
            {
                context.miniGameData.ScriptableSaveElement.IsComplete = true;
                context.miniGameData.MiniGameBadge.ScriptableSaveElement.IsComplete = true;
                GameController.SavePlayerProgressToPlayerPrefs();
            }
            GameController.SceneController.LoadScene(GameController.Metrics.MainMenuScene);
        }
    }
}