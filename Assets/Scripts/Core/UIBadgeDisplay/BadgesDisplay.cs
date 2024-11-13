using NomDuJeu.Core;
using NomDuJeu.Scriptables.Core;
using UnityEngine;
using UnityEngine.UI;

namespace NomDuJeu.UIBadgeDisplay.Core
{
    public class BadgesDisplay : MonoBehaviour
    {
        [SerializeField] private Image[] _badgesDisplay;
        
        [SerializeField] private Sprite _badgeNotCompleted;
        private BadgeScriptable[] _badgesData;

        [SerializeField] private Toggle[] _toggles;

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
            _badgesData = Resources.LoadAll<BadgeScriptable>("SaveScriptables/Badges");
        }

        private void Start()
        {
            RefreshUI();
        }

        private void RefreshUI()
        {
            Debug.Log("Refreshing UI");
            
            for (int i = 0; i < _badgesDisplay.Length; i++)
            {
                if (_badgesData[i].ScriptableSaveElement.IsComplete)
                {
                    _badgesDisplay[i].sprite = _badgesData[i].BadgeDisplayImage;
                    _toggles[i].isOn = true;
                    continue;
                }
                
                _badgesDisplay[i].sprite = _badgeNotCompleted;
            }
        }

        public void ToggleUnlockAchievement(int index)
        {
            _badgesData[index].ScriptableSaveElement.IsComplete = _toggles[index].isOn;
            
            if (_toggles[index].isOn)
            {
                _badgesDisplay[index].sprite = _badgesData[index].BadgeDisplayImage;
                return;
            }

            _badgesDisplay[index].sprite = _badgeNotCompleted;
        }
        
        public void SaveGameData()
        {
            GameController.SavePlayerProgressToPlayerPrefs();
        }
    }
}