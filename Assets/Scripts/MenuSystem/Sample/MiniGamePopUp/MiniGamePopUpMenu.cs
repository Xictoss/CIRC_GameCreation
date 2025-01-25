using CIRC.Controllers;
using UnityEngine;

namespace CIRC.MenuSystem.MiniGamePopUp
{
    public class MiniGamePopUpMenu : BaseMenu
    {
        public override void OpenMenu()
        {
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