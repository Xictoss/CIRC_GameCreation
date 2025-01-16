using CIRC.Controllers;
using CIRC.MiniGames.Core;

namespace CIRC.MiniGames.Sample
{
    public class TvChannel : MiniGame<TvChannelContext>
    {
        public override void Begin(ref TvChannelContext context)
        {
        }

        public override bool Refresh(ref TvChannelContext context)
        {
            return false;
        }

        public override void End(ref TvChannelContext context, bool isSuccess)
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