using CIRC.Core.Controllers;
using CIRC.Core.MiniGames.Core;
using CIRC.Core.Progression.Core;

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
                SaveManager.Instance.MarkMiniGameCompleted(context.MiniGameData);
                SaveManager.Instance.SaveData();
            }
            
            GameController.SceneController.LoadScene(GameController.Metrics.PlageScene);
        }
    }
}