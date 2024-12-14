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
                context.MiniGameDataOld.SaveElement.IsComplete = true;
                GameController.SaveData.SetPlayerCompleted(context.MiniGameDataOld.SaveElement);
                GameController.SavePlayerProgressToPlayerPrefsOLD();
            }

            GameController.SceneController.LoadScene(GameController.Metrics.PlageScene);
        }
    }
}