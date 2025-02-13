using UnityEngine;

namespace CIRC.MenuSystem
{
    public class UIButtonMenu : MonoBehaviour
    {
        public void CloseMenu(string menuName)
        {
            MenuManager.Instance.TryCloseMenu(menuName);
        }
        
        public void OpenMenu(string menuName)
        {
            MenuManager.Instance.TryOpenMenu(menuName, default);
        }
    }
}