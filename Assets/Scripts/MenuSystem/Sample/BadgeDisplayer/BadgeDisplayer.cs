using CIRC.Collections;
using CIRC.Controllers;
using DG.Tweening;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CIRC.MenuSystem.BadgeDisplayer
{
    public class BadgeDisplayer : BaseMenu
    {
        [SerializeField] private TMP_Text title, desc;
        [SerializeField] private Image display;
        [SerializeField] private Localize titleLocalize, descLocalize;

        [Space(10f)]
        [SerializeField] private float shakeForce, shakeDuration;

        private Tween currentTween;
        
        public override void OpenMenu(MenuContext ctx)
        {
            title.text = ctx.title;
            desc.text = ctx.desc;
            display.sprite = ctx.image;

            titleLocalize.SetTerm(title.text);
            descLocalize.SetTerm(desc.text);
            
            gameObject.SetActive(true);
            
            if (currentTween == null)
            {
                currentTween = transform.DOShakeScale(shakeDuration, shakeForce, 8).OnComplete(() =>
                {
                    currentTween = null;
                });
            }
        }

        public override void CloseMenu()
        {
            gameObject.SetActive(false);
        }
        
        public override string MenuName => GameController.Metrics.BadgeDisplayer;
        public override PriorityScale PriorityScale => PriorityScale.Low;
        public override GameObject Object => gameObject;
    }
}