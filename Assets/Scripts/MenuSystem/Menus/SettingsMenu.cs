using CIRC.Controllers;
using UnityEngine;
using CIRC;

namespace CIRC.MenuSystem.Menus
{
    public class SettingsMenu : MonoBehaviour
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
    }
}