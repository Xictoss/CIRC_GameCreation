using CIRC.Controllers;
using CIRC.MiniGames.Core;

namespace CIRC.MiniGames.Sample
{
    public class HydratationMaisonCanalisation : MiniGame<HydratationMaisonCanalisationContext>
    {
        private int totalFlags;
        
        public override void Begin(ref HydratationMaisonCanalisationContext context)
        {
            
        }

        public override bool Refresh(ref HydratationMaisonCanalisationContext context)
        {
            foreach (RotatingPiece pipe in context.pipes)
            {
                if (pipe.PieceState.HasFlagFast(pipe.WantedState))
                {
                    totalFlags++;
                }
            }
            
            if (totalFlags == context.pipes.Length) return true;

            totalFlags = 0;
            return false;
        }

        public override void End(ref HydratationMaisonCanalisationContext context, bool isSuccess)
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