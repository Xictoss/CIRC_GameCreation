using System;
using System.Collections.Generic;
using CIRC.Core;
using CIRC.Core.Controllers;
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
            StartCoroutine(false.TakeScreenshotAndShare());
        }

        public void OpenScene(int sceneIndex)
        {
            //sceneIndex.LoadScene();
        }

        public void OpenCIRC()
        {
            Application.OpenURL("https://www.iarc.who.int/fr/");
        }

        public void OpenNewsletter()
        {
            Application.OpenURL("https://iarc.us16.list-manage.com/subscribe/?u=c0b11667efc4468c0e8892565&id=787135f357");
        }

        public void QuitGame()
        {
            GameController.QuitGame();
        }
    }
}