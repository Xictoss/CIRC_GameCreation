using CIRC.Core.Progression.Core;
using UnityEngine;
using UnityEngine.UI;

namespace CIRC.Core.UIRelated
{
    public class BadgesDisplay : MonoBehaviour
    {
        [SerializeField] private Image[] _badgesDisplay;
        
        [SerializeField] private Sprite _badgeNotCompleted;
        private MiniGameData[] _miniGameDatas;

        private void OnEnable()
        {
            RefreshUI();
        }

        private void RefreshUI()
        {
            SetAllLocked();
            
            //_miniGameDatas = Resources.LoadAll<MiniGameData>("SaveScriptables/MiniGames");
            int total = 0;
            
            for (int i = 0; i < _miniGameDatas.Length; i++)
            {
                if (_miniGameDatas[i].IsCompleted)
                {
                    _badgesDisplay[i].sprite = _miniGameDatas[i].BadgeDisplay.displayImage;
                    total++;
                }
            }
            
            Debug.Log($"Mini-games Finished : {total}");
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