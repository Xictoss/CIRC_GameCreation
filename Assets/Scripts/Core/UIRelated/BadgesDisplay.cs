using CIRC.Core.Progression.Core;
using UnityEngine;
using UnityEngine.UI;

namespace CIRC.Core.UIRelated
{
    public class BadgesDisplay : MonoBehaviour
    {
        [SerializeField] private Image[] _badgesDisplay;
        
        [SerializeField] private Sprite _badgeNotCompleted;

        private void OnEnable()
        {
            RefreshUI();
        }

        private void RefreshUI()
        {
            SetAllLocked();
            
            //_miniGameDatas = Resources.LoadAll<MiniGameData>("SaveScriptables/MiniGames");
            int total = 0;
            
            
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