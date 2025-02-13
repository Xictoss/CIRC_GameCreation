
using CIRC.Controllers;
using CIRC.MiniGames.Core;

namespace CIRC.MiniGames.Sample
{
    public class AlimentationMaisonRadio : MiniGame<AlimentationMaisonRadioContext>
    {
        public override void Begin(ref AlimentationMaisonRadioContext context)
        {
        }

        public override bool Refresh(ref AlimentationMaisonRadioContext context)
        {
            return context.isArrived;
        }

        public override void End(ref AlimentationMaisonRadioContext context, bool isSuccess)
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