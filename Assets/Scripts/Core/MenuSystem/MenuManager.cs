using System.Collections.Generic;
using CIRC.Core.MenuSystem.Interfaces;
using CIRC.Core.MenuSystem.Menus;
using LTX.Singletons;
using UnityEngine;

namespace CIRC.Core.MenuSystem
{
    public class MenuManager : MonoSingleton<MenuManager>
    {
        [SerializeField] private BaseMenu[] menuObjects;
        private Dictionary<string, IMenu> menus = new Dictionary<string, IMenu>();
        private IMenu currentMenu;

        protected override void Awake()
        {
            base.Awake();
            
            foreach (IMenu menu in menuObjects)
            {
                if (menu != null)
                {
                    menus[menu.MenuID] = menu;
                }
            }
        }
        
        public void OpenMenu(string menuName)
        {
            if (menus.TryGetValue(menuName, out IMenu typedMenu))
            {
                if (typedMenu == currentMenu)
                {
                    CloseCurrentMenu();
                    return;
                }
                
                currentMenu?.Close();
                typedMenu.Open();
                currentMenu = typedMenu; 
                return;
            }

            Debug.LogError("Menu not found.");
        }

        public bool TryGetMenu(string menuName, out IMenu typedMenu)
        {
            if (menus.TryGetValue(menuName, out typedMenu))
            {
                return true;
            }

            Debug.LogError("Menu not found.");
            return false;
        }

        public void CloseCurrentMenu()
        {
            currentMenu?.Close();
            currentMenu = null;
        }

        public void ChangeScene(int sceneIndex)
        {
            sceneIndex.LoadScene();
        }
    }
}