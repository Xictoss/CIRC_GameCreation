using System.Collections.Generic;
using CIRC.Controllers;
using CIRC.Progression;
using UnityEngine;
using UnityEngine.UI;

namespace CIRC.UIRelated
{
    public class BadgesDisplay : MonoBehaviour
    {
        [SerializeField] private BadgeButton[] badgesButton;
        
        [SerializeField] private Sprite _badgeNotCompleted;
        [SerializeField] private BadgeData[] badges;

        private void OnEnable()
        {
            RefreshUI();
        }

        private void RefreshUI()
        {
            Dictionary<string, bool> progressionManagerMiniGameStatus = GameController.ProgressionManager.miniGameStatus;
            MiniGameDataHolder[] miniGameDataHolders = GameController.MiniGamesObserver.miniGames;
            
            
            for (int i = 0; i < badgesButton.Length; i++)
            {
                BadgeButton badgeButton = badgesButton[i];
                BadgeData badge = badges[i];

                bool hadComplete = false;
                foreach ((string key, bool value) in progressionManagerMiniGameStatus)
                {
                    if (!value) continue;
                    
                    for (int index = 0; index < miniGameDataHolders.Length; index++)
                    {
                        MiniGameDataHolder data = miniGameDataHolders[index];

                        if (data.GUID == key && badge.subject == data.gameSubject)
                        {
                            hadComplete = true;
                            break;
                        }
                    }

                    if (hadComplete) break;
                }

                Sprite sprite = hadComplete ? badge.displayImage : _badgeNotCompleted;
                badgeButton.Sync(hadComplete, sprite, badge);
                Debug.Log("do sync");
            }
        }
    }
}