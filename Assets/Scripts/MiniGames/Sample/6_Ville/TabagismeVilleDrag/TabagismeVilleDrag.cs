
using CIRC.Controllers;
using CIRC.MiniGames.Core;

namespace CIRC.MiniGames.Sample
{
    public class TabagismeVilleDrag : MiniGame<TabagismeVilleDragContext>
    {
        public override void Begin(ref TabagismeVilleDragContext context)
        {
        }

        public override bool Refresh(ref TabagismeVilleDragContext context)
        {
            return false;
        }

        public override void End(ref TabagismeVilleDragContext context, bool isSuccess)
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