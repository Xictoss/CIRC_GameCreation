using CIRC.Core.MiniGames.Core;
using CIRC.Core.MiniGames.Core.Interfaces;
using LTX.ChanneledProperties;

namespace CIRC.Core.MenuSystem.Menus
{
    public class PauseMenu : BaseMenu
    {
        private IMiniGameRunner _miniGameRunner;

        private void OnEnable()
        {
            _miniGameRunner = MiniGameManager.Instance.currentMiniGame;
            GameController.TimeScale.AddPriority(this, PriorityTags.None, 0f);
            GameController.TimeScale.ChangeChannelPriority(this, PriorityTags.Highest);
        }   

        private void OnDisable()
        {
            GameController.TimeScale.ChangeChannelPriority(this, PriorityTags.None);
            GameController.TimeScale.RemovePriority(this);
        }
        
        public void LeaveMiniGame()
        {
            MiniGameManager.Instance.StopMiniGame(_miniGameRunner.MiniGame, false);
        }
    }
}