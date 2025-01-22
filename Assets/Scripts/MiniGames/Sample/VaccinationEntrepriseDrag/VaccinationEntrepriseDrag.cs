
using CIRC.Controllers;
using CIRC.MiniGames.Core;

namespace CIRC.MiniGames.Sample
{
    public class VaccinationEntrepriseDrag : MiniGame<VaccinationEntrepriseDragContext>
    {
        public override void Begin(ref VaccinationEntrepriseDragContext context)
        {
        }

        public override bool Refresh(ref VaccinationEntrepriseDragContext context)
        {
            return context.pensement.IsArrived;
        }

        public override void End(ref VaccinationEntrepriseDragContext context, bool isSuccess)
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