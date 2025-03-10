using System;
using CIRC.Collections;
using CIRC.Controllers;
using DG.Tweening;
using I2.Loc;
using UnityEngine;
using UnityEngine.UI;

namespace CIRC.MenuSystem
{
    public class SettingsMenu : BaseMenu
    {
        [Header("Sounds")]
        [SerializeField] private Button soundButton, musicButton;
        [SerializeField] private Sprite[] buttonSprites;
        
        [Space(10f)]
        [SerializeField] private float shakeForce, shakeDuration;
        private Tween currentTween;
        
        public void ShareGame()
        {
            StartCoroutine(StaticFunctions.TakeScreenshotAndShare(false));
        }
        
        public void OpenURL(bool newsLetter)
        {
            if (newsLetter)
            {
                Application.OpenURL("https://www.iarc.who.int/fr/");
            }
            else
            {
                Application.OpenURL("https://www.iarc.who.int/fr/");
            }
        }
        
        public void ResetProgression()
        {
            GameController.ResetProgression();
        }

        public void SetLanguage(bool french)
        {
            if (french)
            {
                LocalizationManager.SetLanguageAndCode("French", "fr");
                LocalizationManager.CurrentLanguage = "French";
            }
            else
            {
                LocalizationManager.SetLanguageAndCode("English", "en");
                LocalizationManager.CurrentLanguage = "English";
            }
        }
        
        public void SetVolumeState(bool sourceIndex)
        {
            AudioSource source = sourceIndex ? SoundManager.Instance.audioSource : SoundManager.Instance.musicSource;
            Button button = sourceIndex ? soundButton : musicButton;
            
            int currentIndex = Array.IndexOf(buttonSprites, button.image.sprite);
            int nextIndex = (currentIndex + 1) % 3;

            button.image.sprite = buttonSprites[nextIndex];
            source.volume = Mathf.Clamp01(0.5f * nextIndex);
        }

        public override void OpenMenu(MenuContext ctx)
        {
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

        public override string MenuName => GameController.Metrics.SettingsMenu;
        public override PriorityScale PriorityScale => PriorityScale.Ultra;
        public override GameObject Object => gameObject;
    }
}