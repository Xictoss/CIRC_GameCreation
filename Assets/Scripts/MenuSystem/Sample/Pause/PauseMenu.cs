using CIRC.Controllers;
using CIRC.MiniGames.Core;
using CIRC.MiniGames.Core.Interfaces;
using LTX.ChanneledProperties;
using UnityEngine;

namespace CIRC.MenuSystem
{
    public class PauseMenu : BaseMenu
    {
        public override string MenuName => GameController.Metrics.PauseMenu;
        public override MenuPriority Priority => MenuPriority.High;
        public override GameObject Object => gameObject;
        
        private IMiniGameRunner _miniGameRunner;

        private void OnEnable()
        {
            _miniGameRunner = MiniGameManager.Instance.currentMiniGame;
            GameController.TimeScale.AddPriority(this, PriorityTags.Highest, 0f);
        }   

        private void OnDisable()
        {
            GameController.TimeScale.RemovePriority(this);
        }
        
        public void LeaveMiniGame()
        {
            MiniGameManager.Instance.StopMiniGame(_miniGameRunner.MiniGame, false);
        }

        public override void OpenMenu(MenuContext ctx)
        {
            gameObject.SetActive(true);
        }

        public override void CloseMenu()
        {
            gameObject.SetActive(false);
        }
    }
}