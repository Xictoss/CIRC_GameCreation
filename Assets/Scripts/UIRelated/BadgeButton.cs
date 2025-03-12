using CIRC.Controllers;
using CIRC.MenuSystem;
using CIRC.Progression;
using UnityEngine;
using UnityEngine.UI;

namespace CIRC.UIRelated
{
    public class BadgeButton : MonoBehaviour
    {
        private BadgeData data;
        [SerializeField] private Button button;

        public void Sync(bool completed, Sprite sprite, BadgeData data)
        {
            button.image.sprite = sprite;
            button.interactable = completed;
            this.data = data;
        }
        
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
