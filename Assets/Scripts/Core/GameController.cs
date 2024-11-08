using System;
using System.Collections.Generic;
using LTX.ChanneledProperties;
using NomDuJeu.Progression.Core;
using NomDuJeu.Scriptables.Core;
using UnityEngine;

namespace NomDuJeu.Core
{
    public static class GameController
    {
        #region PrioritisedProperties

        public static PrioritisedProperty<bool> CursorVisibility { get; private set; }
        public static PrioritisedProperty<CursorLockMode> CursorLockMode { get; private set; }

        #endregion

        public static event Action GameSaved;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void Load()
        {
            Application.wantsToQuit += UnLoad;
            
            SetupCursor();
            LoadPlayerProgressFromPlayerPrefs();
        }

        private static bool UnLoad()
        {
            SavePlayerProgressToPlayerPrefs();
            return true;
        }

        #region Progress Functions

        /*public static void SavePlayerProgress()
        {
            Debug.Log("Saving player progress");
            
            SaveData dataToSave = new SaveData(Application.version);
            List<SaveScriptable> gameProgressElements = LoadGameProgressElements();
            
            foreach (SaveScriptable progressElement in gameProgressElements)
            {
                dataToSave.Write(progressElement.scriptableSaveElement);
            }

            ProgressionController.SaveProgressData(dataToSave);
            
            GameSaved?.Invoke();
        }

        public static void LoadPlayerProgress()
        {
            Debug.Log("Loading player progress");
            
            SaveData playerProgressData = ProgressionController.LoadProgressData();
            List<SaveScriptable> gameProgressElements = LoadGameProgressElements();

            foreach (SaveElement playerSaveElement in playerProgressData.PlayerProgression)
            {
                foreach (SaveScriptable gameSaveElement in gameProgressElements)
                {
                    if (playerSaveElement.guidID == gameSaveElement.scriptableSaveElement.guidID)
                    {
                        gameSaveElement.scriptableSaveElement.isComplete = playerSaveElement.isComplete;
                    }
                }
            }
        }*/
        
        public static void SavePlayerProgressToPlayerPrefs()
        {
            Debug.Log("Saving player progress");
            
            SaveData dataToSave = new SaveData(Application.version);
            List<SaveScriptable> gameProgressElements = LoadGameProgressElements();
            
            foreach (SaveScriptable progressElement in gameProgressElements)
            {
                dataToSave.Write(progressElement.scriptableSaveElement);
            }

            ProgressionController.SaveProgressDataToPlayerPrefs(dataToSave);
            
            GameSaved?.Invoke();
        }
        
        public static void LoadPlayerProgressFromPlayerPrefs()
        {
            Debug.Log("Loading player progress");
            
            SaveData playerProgressData = ProgressionController.LoadProgressDataFromPlayerPrefs();
            List<SaveScriptable> gameProgressElements = LoadGameProgressElements();

            foreach (SaveElement playerSaveElement in playerProgressData.PlayerProgression)
            {
                foreach (SaveScriptable gameSaveElement in gameProgressElements)
                {
                    if (playerSaveElement.guidID == gameSaveElement.scriptableSaveElement.guidID)
                    {
                        gameSaveElement.scriptableSaveElement.isComplete = playerSaveElement.isComplete;
                    }
                }
            }
        }

        #endregion

        private static List<SaveScriptable> LoadGameProgressElements()
        {
            return new List<SaveScriptable>(Resources.LoadAll<SaveScriptable>("GameScriptables"));
        }

        #region Exemple Use Of Prioritised Properties

        private static void SetupCursor()
        {
            CursorVisibility = new PrioritisedProperty<bool>(true);
            CursorLockMode = new PrioritisedProperty<CursorLockMode>(UnityEngine.CursorLockMode.None);

            CursorVisibility.AddOnValueChangeCallback(UpdateCursorVisibility, true);
            CursorLockMode.AddOnValueChangeCallback(UpdateCursorLockMode, true);
        }

        private static void UpdateCursorLockMode(CursorLockMode lockMode)
        {
            Cursor.lockState = lockMode;
        }

        private static void UpdateCursorVisibility(bool isVisible)
        {
            Cursor.visible = isVisible;
        }

        #endregion
    }
}
