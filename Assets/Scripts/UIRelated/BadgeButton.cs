using CIRC.Controllers;
using CIRC.MenuSystem;
using CIRC.Progression;
using UnityEngine;

namespace CIRC.UIRelated
{
    public class BadgeButton : MonoBehaviour
    {
        [SerializeField] private BadgeData data;

        public void OpenBadge()
        {
            MenuContext context = new MenuContext()
            {
                title = data.badgeName,
                desc = data.badgeDesc,
                image = data.displayImage
            };

            MenuManager.Instance.TryOpenMenu(GameMetrics.Global.BadgeDisplayer, context);
        }
    }
}
