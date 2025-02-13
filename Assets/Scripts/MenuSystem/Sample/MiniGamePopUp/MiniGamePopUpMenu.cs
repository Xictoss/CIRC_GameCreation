using CIRC.Controllers;
using TMPro;
using UnityEngine;

namespace CIRC.MenuSystem.MiniGamePopUp
{
    public class MiniGamePopUpMenu : BaseMenu
    {
        [SerializeField] private TMP_Text title, desc;
        
        public override void OpenMenu(MenuContext ctx)
        {
            title.text = ctx.title;
            desc.text = ctx.desc;
            
            gameObject.SetActive(true);
        }

        public override void CloseMenu()
        {
            gameObject.SetActive(false);
        }

        public override string MenuName => GameController.Metrics.MiniGamePopUpMenu;
        public override MenuPriority Priority => MenuPriority.High;
        public override GameObject Object => gameObject;
    }
}