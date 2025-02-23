using CIRC.Collections;
using CIRC.Controllers;
using UnityEngine;

namespace CIRC.MenuSystem
{
    public class BooksMenu : BaseMenu
    {
        public override void OpenMenu(MenuContext ctx)
        {
            gameObject.SetActive(true);
        }

        public override void CloseMenu()
        {
            gameObject.SetActive(false);
        }

        public override string MenuName => GameController.Metrics.BooksMenu;
        public override PriorityScale PriorityScale => PriorityScale.Medium;
        public override GameObject Object => gameObject;
    }
}