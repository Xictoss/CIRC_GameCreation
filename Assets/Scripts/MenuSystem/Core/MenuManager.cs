using System.Collections.Generic;
using CIRC.Controllers;
using CIRC.SceneManagement;
using LTX.Singletons;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CIRC.MenuSystem
{
    public class MenuManager : MonoSingleton<MenuManager>, ILoadScene
    {
        private Dictionary<string, BaseMenu> menus;
        [SerializeField] private BaseMenu[] serializedMenus;
        public BaseMenu currentMenu { get; private set; }

        protected override void Awake()
        {
            base.Awake();
            
            menus = new Dictionary<string, BaseMenu>();
            foreach (BaseMenu menu in serializedMenus)
            {
                menus.TryAdd(menu.MenuName, menu);
            }
            
            //GameController.SceneController.SubToSceneChange(this, PriorityScale.VeryHigh);
        }

        public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {

        }

        public bool TryAddMenu(string menuName, BaseMenu menu)
        {
            if (menus.ContainsKey(menuName)) return false;
            
            return menus.TryAdd(menuName, menu);
        }

        public bool TryOpenMenu(string menuName, MenuContext menuContext)
        {
            bool menu = menus.TryGetValue(menuName, out BaseMenu menuObject);

            if (menu)
            {
                if (currentMenu == null)
                {
                    currentMenu = menuObject;
                    currentMenu.OpenMenu(menuContext);
                    return true;
                }

                if (currentMenu == menuObject)
                {
                    currentMenu.CloseMenu();
                    currentMenu = null;
                    return true;
                }
                
                if (menuObject.PriorityScale >= currentMenu.PriorityScale)
                {
                    currentMenu.CloseMenu();
                    currentMenu = menuObject;
                    currentMenu.OpenMenu(menuContext);
                    return true;
                }

                return false;
            }
            else
            {
                return false;
            }
        }

        public bool TryCloseMenu(string menuName)
        {
            bool menu = menus.TryGetValue(menuName, out BaseMenu menuObject);

            if (menu && menuObject == currentMenu)
            {
                currentMenu.CloseMenu();
                currentMenu = null;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}