
using CIRC.Controllers;
using CIRC.MiniGames.Core;

namespace CIRC.MiniGames.Sample
{
    public class AlcoolLotissementTaper : MiniGame<AlcoolLotissementTaperContext>
    {
        public override void Begin(ref AlcoolLotissementTaperContext context)
        {
        }

        public override bool Refresh(ref AlcoolLotissementTaperContext context)
        {
            return context.isChooseGreat;
        }

        public override void End(ref AlcoolLotissementTaperContext context, bool isSuccess)
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