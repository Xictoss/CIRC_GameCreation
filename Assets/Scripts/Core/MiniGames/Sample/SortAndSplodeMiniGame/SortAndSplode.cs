using CIRC.Core.Controllers;
using CIRC.Core.MiniGames.Core;
using CIRC.Core.Progression.Core;

namespace CIRC.Core.MiniGames.Sample.SortAndSplodeMiniGame
{
    public class SortAndSplode : MiniGame<SortAndSplodeContext>
    {
        public SortAndSplode()
        {
            
        }
        
        public override void Begin(ref SortAndSplodeContext context)
        {
        }

        public override bool Refresh(ref SortAndSplodeContext context)
        {
            return context.Spawner.Remainings == 0 
                   && context.EntityManager.SpawnedEntities.Count == 0;
        }

        public override void End(ref SortAndSplodeContext context, bool isSuccess)
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