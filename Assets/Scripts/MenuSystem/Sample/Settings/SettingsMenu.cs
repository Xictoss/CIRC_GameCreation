using CIRC.Controllers;
using UnityEngine;

namespace CIRC.MenuSystem
{
    public class SettingsMenu : BaseMenu
    {
        public void ShareGame()
        {
            StartCoroutine(StaticFunctions.TakeScreenshotAndShare(false));
        }
        
        public void OpenURL()
        {
            Application.OpenURL("https://www.iarc.who.int/fr/");
        }
        
        public void QuitGame()
        {
            GameController.QuitGame();
        }
        
        public void SetVolumeState()
        {
            
        }

        public override void OpenMenu()
        {
            gameObject.SetActive(true);
        }

        public override void CloseMenu()
        {
            gameObject.SetActive(false);
        }

        public override string MenuName => GameController.Metrics.SettingsMenu;
        public override MenuPriority Priority => MenuPriority.Medium;
        public override GameObject Object => gameObject;
    }
}