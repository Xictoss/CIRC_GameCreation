using NomDuJeu.Core;
using NomDuJeu.Scriptables.Core;
using UnityEngine;
using UnityEngine.UI;

namespace NomDuJeu.UIBadgeDisplay.Core
{
    public class DisplayBadgeAndMiniGame : MonoBehaviour
    {
        [SerializeField] private Image badgeDisplay;
        
        [SerializeField] private Sprite badgeNotCompleted;
        private MiniGameScriptable miniGameData;

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
            miniGameData = Resources.Load<MiniGameScriptable>("SaveScriptables/MiniGames/1_SortAndSplode");
        }

        private void Start()
        {
            RefreshUI();
        }

        private void RefreshUI()
        {
            Debug.Log("Refreshing UI");
            
            if (miniGameData.scriptableSaveElement.isComplete)
            {
                badgeDisplay.sprite = miniGameData.miniGameBadge.badgeDisplayImage;
                return;
            }
            
            badgeDisplay.sprite = badgeNotCompleted;
        }

        public void PlayGame()
        {
            SceneManager.LoadScene(1);
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