using CIRC.Collections;
using CIRC.Controllers;
using DG.Tweening;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CIRC.MenuSystem.MiniGameReward
{
    public class MiniGameReward : BaseMenu
    {
        [SerializeField] private TMP_Text endDesc, endExplication;
        [SerializeField] private Image display;
        [SerializeField] private Localize descLocalize, titleLocalize;

        [Space(10f)]
        [SerializeField] private float shakeForce, shakeDuration;

        private Tween currentTween;
        
        public override void OpenMenu(MenuContext ctx)
        {
            endDesc.text = ctx.endDesc;
            endExplication.text = ctx.endExplication;
            display.sprite = ctx.image;
            
            descLocalize.SetTerm(endExplication.text);
            titleLocalize.SetTerm(endDesc.text);
            
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
        
        public override string MenuName => GameController.Metrics.MiniGameReward;
        public override PriorityScale PriorityScale => PriorityScale.VeryHigh;
        public override GameObject Object => gameObject;
    }
}