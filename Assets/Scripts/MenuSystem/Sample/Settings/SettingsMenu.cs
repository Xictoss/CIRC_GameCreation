using CIRC.Collections;
using CIRC.Controllers;
using DG.Tweening;
using UnityEngine;

namespace CIRC.MenuSystem
{
    public class SettingsMenu : BaseMenu
    {
        [Space(10f)]
        [SerializeField] private float shakeForce, shakeDuration;
        private Tween currentTween;
        
        public void ShareGame()
        {
            StartCoroutine(StaticFunctions.TakeScreenshotAndShare(false));
        }
        
        public void OpenURL()
        {
            Application.OpenURL("https://www.iarc.who.int/fr/");
        }
        
        public void ResetProgression()
        {
            GameController.ResetProgression();
        }
        
        public void SetVolumeState()
        {
            
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