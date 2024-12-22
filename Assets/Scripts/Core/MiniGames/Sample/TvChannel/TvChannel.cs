using CIRC.Core.Controllers;
using CIRC.Core.MiniGames.Core;
using CIRC.Core.Progression.Core;

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
                SaveManager.Instance.MarkMiniGameCompleted(
                    context.MiniGameData.MiniGameId,
                    context.MiniGameData.BadgeDisplay,
                    context.MiniGameData.GameSubject
                );
                SaveManager.Instance.SaveData();
            }

            GameController.SceneController.LoadScene(GameController.Metrics.PlageScene);
        }
    }
}