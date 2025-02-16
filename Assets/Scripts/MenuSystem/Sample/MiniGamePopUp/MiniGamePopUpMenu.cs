using CIRC.Controllers;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace CIRC.MenuSystem.MiniGamePopUp
{
    public class MiniGamePopUpMenu : BaseMenu
    {
        [SerializeField] private TMP_Text title, desc;

        [Space(10f)]
        [SerializeField] private float shakeForce;

        private Tween currentTween;
        
        public override void OpenMenu(MenuContext ctx)
        {
            title.text = ctx.title;
            desc.text = ctx.desc;
            
            gameObject.SetActive(true);
            
            if (currentTween == null)
            {
                currentTween = transform.DOShakeScale(0.5f, shakeForce, 10).OnComplete(() =>
                {
                    currentTween = null;
                });
            }
        }

        public override void CloseMenu()
        {
            gameObject.SetActive(false);
        }

        public override string MenuName => GameController.Metrics.MiniGamePopUpMenu;
        public override PriorityScale PriorityScale => PriorityScale.High;
        public override GameObject Object => gameObject;
    }
}