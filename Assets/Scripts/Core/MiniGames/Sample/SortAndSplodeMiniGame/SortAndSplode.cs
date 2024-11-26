using CIRC.Core.MiniGames.Core;

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
                context.MiniGameData.ScriptableSaveElement.IsComplete = true;
                context.MiniGameData.MiniGameBadge.ScriptableSaveElement.IsComplete = true;
                GameController.SavePlayerProgressToPlayerPrefs();
            }
            GameController.SceneController.LoadScene(GameController.Metrics.PlageScene);
        }
    }
}