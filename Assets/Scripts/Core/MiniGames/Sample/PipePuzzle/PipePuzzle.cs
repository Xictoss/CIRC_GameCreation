using CIRC.Core.Controllers;
using CIRC.Core.MiniGames.Core;
using CIRC.Core.Progression.Core;

namespace CIRC.Core.MiniGames.Sample.Core.MiniGames.Sample.PipePuzzle
{
    public class PipePuzzle : MiniGame<PipePuzzleContext>
    {
        private int totalFlags;
        
        public override void Begin(ref PipePuzzleContext context)
        {
            
        }

        public override bool Refresh(ref PipePuzzleContext context)
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

        public override void End(ref PipePuzzleContext context, bool isSuccess)
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