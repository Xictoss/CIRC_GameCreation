using CIRC.Core.Controllers;
using CIRC.Core.Scriptables.Core;
using UnityEngine;
using UnityEngine.UI;

namespace CIRC.Core.UIBadgeDisplay
{
    public class DisplayBadgeAndMiniGame : MonoBehaviour
    {
        [SerializeField] private Image _badgeDisplay;
        
        [SerializeField] private Sprite _badgeNotCompleted;
        private MiniGameData _miniGameData;

        private void OnEnable()
        {
            GameController.GameSaved += RefreshUI;
        }
        private void OnDisable()
        {
            GameController.GameSaved -= RefreshUI;
        }

        private void Awake()
        {
            _miniGameData = Resources.Load<MiniGameData>("SaveScriptables/MiniGames/1_SortAndSplode");
        }

        private void Start()
        {
            RefreshUI();
        }

        private void RefreshUI()
        {
            //Debug.Log("Refreshing UI");
            
            if (_miniGameData.saveElement.isComplete)
            {
                _badgeDisplay.sprite = _miniGameData.badge.displayImage;
                return;
            }
            
            _badgeDisplay.sprite = _badgeNotCompleted;
        }

        public void PlayGame()
        {
            
            //1.LoadScene();
        }
        
        public void SaveGameData()
        {
            GameController.SavePlayerProgressToPlayerPrefs();
        }

        public void ResetPlayerProgress()
        {
            GameController.DeleteProgress();
            GameController.SavePlayerProgressToPlayerPrefs();
        }
    }
}