using CIRC.Core.Scriptables.Core;
using UnityEngine;
using UnityEngine.UI;

namespace CIRC.Core.UIBadgeDisplay
{
    public class BadgesDisplay : MonoBehaviour
    {
        [SerializeField] private Image[] _badgesDisplay;
        
        [SerializeField] private Sprite _badgeNotCompleted;
        private BadgeScriptable[] _badgesData;

        [SerializeField] private Toggle[] _toggles;

        private void OnEnable()
        {
            GameController.LoadPlayerProgressFromPlayerPrefs();
            RefreshUI();
        }

        private void RefreshUI()
        {
            Debug.Log("Refreshing UI");
            
            _badgesData = Resources.LoadAll<BadgeScriptable>("SaveScriptables/Badges");
            
            SetAllLocked();
            
            for (int i = 0; i < _badgesData.Length; i++)
            {
                if (_badgesData[i].ScriptableSaveElement.IsComplete)
                {
                    _badgesDisplay[i].sprite = _badgesData[i].BadgeDisplayImage;
                }
            }
        }

        private void SetAllLocked()
        {
            foreach (Image badge in _badgesDisplay)
            {
                badge.sprite = _badgeNotCompleted;
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