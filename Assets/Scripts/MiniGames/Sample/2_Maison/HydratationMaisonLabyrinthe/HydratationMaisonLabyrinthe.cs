using CIRC.Controllers;
using CIRC.MiniGames.Core;

namespace CIRC.MiniGames.Sample
{
    public class HydratationMaisonLabyrinthe : MiniGame<HydratationMaisonLabyrintheContext>
    {
        public override void Begin(ref HydratationMaisonLabyrintheContext context)
        {
        }

        public override bool Refresh(ref HydratationMaisonLabyrintheContext context)
        {
            return context.remainingDrinks <= 0;
        }

        public override void End(ref HydratationMaisonLabyrintheContext context, bool isSuccess)
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