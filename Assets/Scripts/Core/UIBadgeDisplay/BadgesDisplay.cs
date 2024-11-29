using CIRC.Core.Controllers;
using CIRC.Core.Scriptables.Core;
using UnityEngine;
using UnityEngine.UI;

namespace CIRC.Core.UIBadgeDisplay
{
    public class BadgesDisplay : MonoBehaviour
    {
        [SerializeField] private Image[] _badgesDisplay;
        
        [SerializeField] private Sprite _badgeNotCompleted;
        private BadgeData[] _badgesData;

        [SerializeField] private Toggle[] _toggles;

        private void OnEnable()
        {
            GameController.LoadPlayerProgressFromPlayerPrefs();
            RefreshUI();
        }

        private void RefreshUI()
        {
            Debug.Log("Refreshing UI");
            
            _badgesData = Resources.LoadAll<BadgeData>("SaveScriptables/Badges");
            
            SetAllLocked();
            
            for (int i = 0; i < _badgesData.Length; i++)
            {
                if (_badgesData[i].saveElement.isComplete)
                {
                    _badgesDisplay[i].sprite = _badgesData[i].displayImage;
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
            _badgesData[index].saveElement.isComplete = _toggles[index].isOn;
            
            if (_toggles[index].isOn)
            {
                _badgesDisplay[index].sprite = _badgesData[index].displayImage;
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