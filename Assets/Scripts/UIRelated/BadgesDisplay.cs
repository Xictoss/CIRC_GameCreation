using CIRC.Controllers;
using UnityEngine;
using UnityEngine.UI;

namespace CIRC.UIRelated
{
    public class BadgesDisplay : MonoBehaviour
    {
        [SerializeField] private Image[] _badgesDisplay;
        
        [SerializeField] private Sprite _badgeNotCompleted;
        [SerializeField] private Sprite _badgeCompleted;
        
        private void OnEnable()
        {
            RefreshUI();
        }

        private void RefreshUI()
        {
            int index = 0;
            foreach (var kvp in GameController.ProgressionManager.miniGameStatus)
            {
                Image badge = _badgesDisplay[index];
                
                if (kvp.Value) //MiniGame completed
                {
                    badge.sprite = _badgeCompleted;
                }
                else
                {
                    badge.sprite = _badgeNotCompleted;
                }
                
                index++;
            }
        }
    }
}