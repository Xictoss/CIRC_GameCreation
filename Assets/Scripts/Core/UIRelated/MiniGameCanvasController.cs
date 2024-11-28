using CIRC.Core;
using CIRC.Core.Controllers;
using CIRC.Core.MiniGames.Core;
using CIRC.Core.MiniGames.Core.Interfaces;
using LTX.ChanneledProperties;
using UnityEngine;

namespace NomDuJeu.UIRelated
{
    public class MiniGameCanvasController : MonoBehaviour
    {
        [SerializeField] private GameObject pausePanel;
        private bool isPaused;
        private IMiniGameRunner _miniGameRunner;

        private void OnEnable()
        {
            MiniGameManager.Instance.OnMiniGameStarted += AssignMiniGame;
            GameController.TimeScale.AddPriority(this, PriorityTags.None, 0f);
        }   

        private void OnDisable()
        {
            MiniGameManager.Instance.OnMiniGameStarted -= AssignMiniGame;
            GameController.TimeScale.RemovePriority(this);
        }

        public void PauseState()
        {
            isPaused = !isPaused;
            pausePanel.SetActive(isPaused);
            
            GameController.TimeScale.ChangeChannelPriority(this, isPaused ? PriorityTags.Highest : PriorityTags.None);
        }
        
        public void LeaveMiniGame()
        {
            MiniGameManager.Instance.StopMiniGame(_miniGameRunner.MiniGame, false);
        }

        private void AssignMiniGame(IMiniGameRunner miniGameRunner)
        {
            _miniGameRunner = miniGameRunner;
        }
    }
}
