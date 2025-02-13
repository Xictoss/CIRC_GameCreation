using System.Collections.Generic;
using CIRC.Controllers;
using DG.Tweening;
using LTX.Singletons;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CIRC.MenuSystem
{
    public class MenuManager : MonoSingleton<MenuManager>
    {
        private Dictionary<string, BaseMenu> menus;
        public BaseMenu currentMenu { get; private set; }

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

            if (GameController.SceneController.previousScene == default)
            {
                return;
            }
            if (GameController.SceneController.previousScene.StartsWith("Assets/Scenes/MainScenes/MiniGames"))
            {
                TryOpenMenu(GameMetrics.Global.MiniGameReward, new MenuContext()
                {
                    title = GameController.MiniGameRegister.currentMiniGame.miniGameName,
                    desc = "Melekoum"
                });
                Debug.Log("Previous scene is in the MiniGames folder.");
            }
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
                
                if (menuObject.Priority >= currentMenu.Priority)
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