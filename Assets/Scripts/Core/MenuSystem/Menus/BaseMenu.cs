using CIRC.Core.MenuSystem.Interfaces;
using UnityEngine;

namespace CIRC.Core.MenuSystem.Menus
{
    public class BaseMenu : MonoBehaviour, IMenu
    {
        public string MenuID => name;
        public bool IsOpen { get; private set; }
         
        public void Open()
        {
            gameObject.SetActive(true);
            IsOpen = true;
        }

        public void Close()
        {
            gameObject.SetActive(false);
            IsOpen = false;
        }
    }
}