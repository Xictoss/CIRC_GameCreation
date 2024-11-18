using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace NomDuJeu.Core
{
    public class CanvasController : MonoBehaviour
    {
        [field : SerializeField] private List<GameObject> _panels = new List<GameObject>();
        
        public MenuState menuState { get; private set; }
        public enum MenuState
        {
            None = -1,
            Main = 0,
            Settings = 1,
            Book = 2,
            Levels = 3,
            MiniGames = 4,
            Credits = 5,
        }

        private void OnStateChange(MenuState newState)
        {
            menuState = newState;

            switch (menuState)
            {
                case MenuState.None:
                    break;
                case MenuState.Main:
                    break;
                case MenuState.Settings:
                    break;
                case MenuState.Book:
                    break;
                case MenuState.Levels:
                    break;
                case MenuState.MiniGames:
                    break;
                case MenuState.Credits:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        
        public void ChangeState(int stateIndex)
        {
            OnStateChange((MenuState)stateIndex);
        }

        public void OpenPanel(int index)
        {
            if ((int)menuState is > 1 and < 5 && index != (int)menuState)
            {
                _panels[(int)menuState].SetActive(false);
            }
            
            _panels[index].SetActive(!_panels[index].activeInHierarchy);
            ChangeState(index);
        }

        public void SetVolumeState()
        {
            
        }

        public void ShareGame()
        {
            StartCoroutine(TakeScreenshotAndShare());
        }
        
        private IEnumerator TakeScreenshotAndShare()
        {
	        yield return new WaitForEndOfFrame();

	        Texture2D ss = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
	        ss.ReadPixels(new Rect(0, 0, Screen.width, Screen.height ), 0, 0);
	        ss.Apply();

	        string filePath = Path.Combine(Application.temporaryCachePath, "shared img.png");
	        File.WriteAllBytes(filePath, ss.EncodeToPNG());

	        // To avoid memory leaks
	        Destroy(ss);

	        new NativeShare().AddFile(filePath)
		        .SetSubject("CIRC Game").SetText("Essaye ce nouveau jeu sur la prévention contre le cancer").SetUrl("https://github.com/Xictoss/CIRC_GameCreation")
		        .Share();

	        // Share on WhatsApp only, if installed (Android only)
	        //if( NativeShare.TargetExists( "com.whatsapp" ) )
	        //	new NativeShare().AddFile( filePath ).AddTarget( "com.whatsapp" ).Share();
        }

        public void OpenScene(int sceneIndex)
        {
            sceneIndex.LoadScene();
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
    }
}