using CIRC.Collections;
using CIRC.Controllers;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CIRC.MenuSystem.MiniGamePopUp
{
    public class MiniGamePopUpMenu : BaseMenu
    {
        [SerializeField] private TMP_Text title, desc;
        [SerializeField] private Button button;

        [Space(10f)]
        [SerializeField] private float shakeForce, shakeDuration;

        private MenuContext context;
        private Tween currentTween;
        
        public override void OpenMenu(MenuContext ctx)
        {
            context = ctx;
            
            title.text = context.title;
            desc.text = context.desc;

            button.onClick.AddListener(OnButtonClick);
            
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
            button.onClick.RemoveListener(OnButtonClick);
            
            gameObject.SetActive(false);
        }

        private void OnButtonClick()
        {
            GameController.SceneController.LoadScene(context.scene);
        }

        public override string MenuName => GameController.Metrics.MiniGamePopUpMenu;
        public override PriorityScale PriorityScale => PriorityScale.High;
        public override GameObject Object => gameObject;
    }
}