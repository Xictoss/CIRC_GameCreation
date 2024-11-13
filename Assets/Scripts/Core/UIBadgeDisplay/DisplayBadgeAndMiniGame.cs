using NomDuJeu.Core;
using NomDuJeu.Scriptables.Core;
using UnityEngine;
using UnityEngine.UI;

namespace NomDuJeu.UIBadgeDisplay.Core
{
    public class DisplayBadgeAndMiniGame : MonoBehaviour
    {
        [SerializeField] private Image _badgeDisplay;
        
        [SerializeField] private Sprite _badgeNotCompleted;
        private MiniGameScriptable _miniGameData;

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
            _miniGameData = Resources.Load<MiniGameScriptable>("SaveScriptables/MiniGames/1_SortAndSplode");
        }

        private void Start()
        {
            RefreshUI();
        }

        private void RefreshUI()
        {
            //Debug.Log("Refreshing UI");
            
            if (_miniGameData.ScriptableSaveElement.IsComplete)
            {
                _badgeDisplay.sprite = _miniGameData.MiniGameBadge.BadgeDisplayImage;
                return;
            }
            
            _badgeDisplay.sprite = _badgeNotCompleted;
        }

        public void PlayGame()
        {
            
            1.LoadScene();
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