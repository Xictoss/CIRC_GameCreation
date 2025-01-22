
using CIRC.Controllers;
using CIRC.MiniGames.Core;

namespace CIRC.MiniGames.Sample
{
    public class ActiviteEntrepriseDrag : MiniGame<ActiviteEntrepriseDragContext>
    {
        public override void Begin(ref ActiviteEntrepriseDragContext context)
        {
        }

        public override bool Refresh(ref ActiviteEntrepriseDragContext context)
        {
            for (int i = 0; i < context.posters.Length; i++)
            {
                if (!context.posters[i].IsArrived) return false;
            }

            return true;
        }

        public override void End(ref ActiviteEntrepriseDragContext context, bool isSuccess)
        {
            if (isSuccess)
            {
                GameController.ProgressionManager.CompleteMiniGame(context.miniGameData.GUID);
                GameController.SaveProgress();
            }

            GameController.SceneController.LoadScene(GameController.Metrics.PlageScene);
        }
    }
}