using System;
using System.Collections.Generic;
using LTX.Singletons;
using UnityEngine;

namespace CIRC.MenuSystem
{
    public class MenuManager : MonoSingleton<MenuManager>
    {
        private Dictionary<string, BaseMenu> menus;
        [SerializeField] private BaseMenu[] serializedMenus;
        [field : SerializeField]
        public BaseMenu currentMenu { get; private set; }

        public event Action<BaseMenu> OnMenuOpen;
        public event Action OnMenuClose;

        protected override void Awake()
        {
            base.Awake();
            
            menus = new Dictionary<string, BaseMenu>();
            foreach (BaseMenu menu in serializedMenus)
            {
                TryAddMenu(menu.MenuName, menu);
                menu.Object.SetActive(false);
            }

            currentMenu = null;
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
                    OnMenuOpen?.Invoke(menuObject);
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
                    OnMenuOpen?.Invoke(menuObject);
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
                OnMenuClose?.Invoke();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}