using UnityEngine;

namespace CIRC.Core.MenuSystem.Menus
{
    public class SettingsMenu : BaseMenu
    {
        public void ShareGame()
        {
            StartCoroutine(false.TakeScreenshotAndShare());
        }
        
        public void OpenURL()
        {
            Application.OpenURL("https://www.iarc.who.int/fr/");
        }
        
        public void QuitGame()
        {
            GameController.QuitGame();
        }

        public void ResetProgress()
        {
            GameController.DeleteProgress();
        }
        
        public void SetVolumeState()
        {
            
        }
    }
}