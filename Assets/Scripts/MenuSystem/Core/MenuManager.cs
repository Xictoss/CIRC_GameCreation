using System.Collections.Generic;
using DG.Tweening;
using LTX.Singletons;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CIRC.MenuSystem
{
    public class MenuManager : MonoSingleton<MenuManager>
    {
        private Dictionary<string, BaseMenu> menus;
        private BaseMenu currentMenu;

        protected override void Awake()
        {
            base.Awake();
            if (MenuManager.Instance != this) Destroy(this);
            
            menus = new Dictionary<string, BaseMenu>();

            DontDestroyOnLoad(this);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            menus.Clear();
            currentMenu = null;

            BaseMenu[] newMenus = FindObjectsByType<BaseMenu>(FindObjectsInactive.Include, FindObjectsSortMode.None);
            for (int i = 0; i < newMenus.Length; i++)
            {
                bool success = TryAddMenu(newMenus[i].MenuName, newMenus[i]);
                //if (success) Debug.Log($"Added Menu : {newMenus[i].MenuName}");
            }
        }

        public bool TryAddMenu(string menuName, BaseMenu menu)
        {
            if (menus.ContainsKey(menuName)) return false;
            
            return menus.TryAdd(menuName, menu);
        }

        public bool TryOpenMenu(string menuName, MenuContext menuContext, float shakeForce)
        {
            bool menu = menus.TryGetValue(menuName, out BaseMenu menuObject);

            if (menu)
            {
                if (currentMenu != null && (currentMenu == menuObject || menuObject.Priority >= currentMenu.Priority))
                {
                    currentMenu.CloseMenu();
                    currentMenu = null;
                }

                if (currentMenu == null || menuObject.Priority >= currentMenu.Priority)
                {
                    currentMenu = menuObject;
                    currentMenu.OpenMenu(menuContext);
                    currentMenu.transform.DOShakeScale(0.5f, shakeForce, 5);
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