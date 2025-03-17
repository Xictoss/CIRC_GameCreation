
using CIRC.Controllers;
using CIRC.MiniGames.Core;

namespace CIRC.MiniGames.Sample
{
    public class VaccinationVilleDrag : MiniGame<VaccinationVilleDragContext>
    {
        public override void Begin(ref VaccinationVilleDragContext context)
        {
        }

        public override bool Refresh(ref VaccinationVilleDragContext context)
        {
            return context.IsPlaced;
        }

        public override void End(ref VaccinationVilleDragContext context, bool isSuccess)
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