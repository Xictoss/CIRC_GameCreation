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