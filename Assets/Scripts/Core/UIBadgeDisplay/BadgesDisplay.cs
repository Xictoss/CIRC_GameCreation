using System;
using System.Collections.Generic;
using NomDuJeu.Core;
using NomDuJeu.Scriptables.Core;
using UnityEngine;
using UnityEngine.UI;

namespace NomDuJeu.UIBadgeDisplay.Core
{
    public class BadgesDisplay : MonoBehaviour
    {
        [SerializeField] private Image[] badgesDisplay;
        
        [SerializeField] private Sprite badgeNotCompleted;
        private BadgeScriptable[] badgesData;

        [SerializeField] private Toggle[] toggles;

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
            badgesData = Resources.LoadAll<BadgeScriptable>("SaveScriptables/Badges");
        }

        private void Start()
        {
            RefreshUI();
        }

        private void RefreshUI()
        {
            Debug.Log("Refreshing UI");
            
            for (int i = 0; i < badgesDisplay.Length; i++)
            {
                if (badgesData[i].scriptableSaveElement.isComplete)
                {
                    badgesDisplay[i].sprite = badgesData[i].badgeDisplayImage;
                    toggles[i].isOn = true;
                    continue;
                }
                
                badgesDisplay[i].sprite = badgeNotCompleted;
            }
        }

        public void ToggleUnlockAchievement(int index)
        {
            badgesData[index].scriptableSaveElement.isComplete = toggles[index].isOn;
            
            if (toggles[index].isOn)
            {
                badgesDisplay[index].sprite = badgesData[index].badgeDisplayImage;
                return;
            }

            badgesDisplay[index].sprite = badgeNotCompleted;
        }
        
        public void SaveGameData()
        {
            GameController.SavePlayerProgressToPlayerPrefs();
        }
    }
}