using CIRC.Collections;
using CIRC.Controllers;
using DG.Tweening;
using UnityEngine;

namespace CIRC.MenuSystem
{
    public class MiniGamesMenu : BaseMenu
    {
        [Space(10f)]
        [SerializeField] private float shakeForce, shakeDuration;
        private Tween currentTween;
        
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

        public override string MenuName => GameController.Metrics.MiniGamesMenu;
        public override PriorityScale PriorityScale => PriorityScale.Medium;
        public override GameObject Object => gameObject;
    }
}