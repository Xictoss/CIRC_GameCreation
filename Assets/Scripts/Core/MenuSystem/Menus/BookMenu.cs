using CIRC.Core.Scriptables.Core;
using UnityEngine;
using UnityEngine.UI;

namespace CIRC.Core.MenuSystem.Menus
{
    public class BookMenu
    {
        [SerializeField] private Image[] _badgesDisplay;
        
        [SerializeField] private Sprite _badgeNotCompleted;
        private BadgeData[] _badgesData;
        
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
    }
}