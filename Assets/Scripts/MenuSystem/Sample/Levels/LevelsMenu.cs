using CIRC.Controllers;
using UnityEngine;

namespace CIRC.MenuSystem
{
    public class LevelsMenu : BaseMenu
    {
        public override void OpenMenu(MenuContext ctx)
        {
            gameObject.SetActive(true);
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