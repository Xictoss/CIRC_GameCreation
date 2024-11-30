using CIRC.Core.Controllers;
using CIRC.Core.MiniGames.Core;

namespace CIRC.Core.MiniGames.Sample.TvChannel
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
                context.miniGameData.saveElement.isComplete = true;
                context.miniGameData.badge.saveElement.isComplete = true;
                GameController.SavePlayerProgressToPlayerPrefs();
            }

            GameController.SceneController.LoadScene(GameController.Metrics.PlageScene);
        }
    }
}