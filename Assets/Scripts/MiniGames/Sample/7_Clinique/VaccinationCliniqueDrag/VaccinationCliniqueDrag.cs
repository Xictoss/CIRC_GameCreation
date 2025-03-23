
using CIRC.Controllers;
using CIRC.MiniGames.Core;

namespace CIRC.MiniGames.Sample
{
    public class VaccinationCliniqueDrag : MiniGame<VaccinationCliniqueDragContext>
    {
        public override void Begin(ref VaccinationCliniqueDragContext context)
        {
        }

        public override bool Refresh(ref VaccinationCliniqueDragContext context)
        {
            return context.IsPlaced;
        }

        public override void End(ref VaccinationCliniqueDragContext context, bool isSuccess)
        {
            if (isSuccess)
            {
                GameController.ProgressionManager.CompleteMiniGame(context.miniGameData.GUID);
                GameController.SaveProgress();
            }

            GameController.SceneController.LoadScene(GameController.Metrics.CliniqueScene);
        }
    }
}