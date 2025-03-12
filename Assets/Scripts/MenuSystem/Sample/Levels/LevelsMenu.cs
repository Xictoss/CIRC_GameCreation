using System;
using System.Linq;
using CIRC.Collections;
using CIRC.Controllers;
using DevLocker.Utils;
using DG.Tweening;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace CIRC.MenuSystem
{
    public class LevelsMenu : BaseMenu
    {
        [SerializeField] private SceneReference[] levelScenes;
        [SerializeField] private TMP_Text levelName;
        [SerializeField] private Localize textLocalization;
        [SerializeField] private Sprite[] levelSprites;
        [SerializeField] private Image[] selectedLevels;
        [SerializeField] private Image levelImage;
        private int currentLevel;
        
        [Space(10f)]
        [SerializeField] private float shakeForce, shakeDuration;
        private Tween currentTween;
        private bool didAwake;

        private Color colorOn => new Color(255, 255, 255, 1);
        private Color colorOff => new Color(255, 255, 255, 0);
        
        public void SwitchLevel(int direction)
        {
            for (int i = 0; i < selectedLevels.Length; i++)
            {
                selectedLevels[i].color = colorOff;
            }
            
            currentLevel += direction;
            currentLevel = currentLevel < 0 ? 5 : currentLevel > 5 ? 0 : currentLevel;

            levelImage.sprite = levelSprites[currentLevel];
            levelName.text = GameMetrics.Global.SceneNames[currentLevel];
            textLocalization.SetTerm(levelName.text);
            selectedLevels[currentLevel].color = colorOn;
            
            //Debug.Log($"Current Level : {currentLevel}");
        }

        public void PlayLevel()
        {
            MenuManager.Instance.TryCloseMenu(MenuName);
            GameController.SceneController.LoadScene(levelScenes[currentLevel]);
        }
        
        public override void OpenMenu(MenuContext ctx)
        {
            if (!didAwake)
            {
                Scene scene = SceneManager.GetActiveScene();
                currentLevel = Array.IndexOf(levelScenes, levelScenes.FirstOrDefault(level => level.BuildIndex == scene.buildIndex));
                didAwake = true;
            }
            
            SwitchLevel(0);
            gameObject.SetActive(true);
            
            if (currentTween == null)
            {
                currentTween = transform.DOShakeScale(shakeDuration, shakeForce, 10).OnComplete(() =>
                {
                    currentTween = null;
                });
            }
        }

        public override void CloseMenu()
        {
            gameObject.SetActive(false);
        }

        public override string MenuName => GameController.Metrics.LevelsMenu;
        public override PriorityScale PriorityScale => PriorityScale.Medium;
        public override GameObject Object => gameObject;
    }
}