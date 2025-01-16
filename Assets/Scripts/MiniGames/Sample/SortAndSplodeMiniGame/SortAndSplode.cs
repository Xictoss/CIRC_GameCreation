
using CIRC.Controllers;
using CIRC.MiniGames.Core;

namespace CIRC.MiniGames.Sample
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
                GameController.ProgressionManager.CompleteMiniGame(context.MiniGameData.GUID);
                GameController.SaveProgress();
            }
            
            GameController.SceneController.LoadScene(GameController.Metrics.PlageScene);
        }
    }
}