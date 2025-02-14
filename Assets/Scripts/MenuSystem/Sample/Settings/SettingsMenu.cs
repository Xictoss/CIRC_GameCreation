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
        
        public void ResetProgression()
        {
            GameController.ResetProgression();
        }
        
        public void SetVolumeState()
        {
            
        }

        public override void OpenMenu(MenuContext ctx)
        {
            gameObject.SetActive(true);
        }

        public override void CloseMenu()
        {
            gameObject.SetActive(false);
        }

        public override string MenuName => GameController.Metrics.SettingsMenu;
        public override MenuPriority Priority => MenuPriority.Ultra;
        public override GameObject Object => gameObject;
    }
}