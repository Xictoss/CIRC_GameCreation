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
            Application.targetFrameRate = 60;
            
            SetupCursor();
            LoadPlayerProgressFromPlayerPrefs();
        }

        private static bool UnLoad()
        {
            SavePlayerProgressToPlayerPrefs();
            return true;
        }

        #region Progress Functions
        
        public static void SavePlayerProgressToPlayerPrefs()
        {
            Debug.Log("Saving player progress");
            
            SaveData dataToSave = new SaveData(Application.version);
            List<SaveScriptable> gameProgressElements = LoadGameProgressElements();
            
            foreach (SaveScriptable progressElement in gameProgressElements)
            {
                dataToSave.Write(progressElement.ScriptableSaveElement);
            }

            ProgressionController.SaveProgressDataToPlayerPrefs(dataToSave);
            //ProgressionController.SaveProgressData(dataToSave);
            
            GameSaved?.Invoke();
        }
        
        public static void LoadPlayerProgressFromPlayerPrefs()
        {
            Debug.Log("Loading player progress");
            
            SaveData playerProgressData = ProgressionController.LoadProgressDataFromPlayerPrefs();
            //SaveData playerProgressData = ProgressionController.LoadProgressData();
            
            List<SaveScriptable> gameProgressElements = LoadGameProgressElements();

            foreach (SaveElement playerSaveElement in playerProgressData.PlayerProgression)
            {
                foreach (SaveScriptable gameSaveElement in gameProgressElements)
                {
                    if (playerSaveElement.GuidID == gameSaveElement.ScriptableSaveElement.GuidID)
                    {
                        if (playerProgressData.SaveVersion == "0")
                        {
                            gameSaveElement.ScriptableSaveElement.IsComplete = false;
                            continue;
                        }
                        gameSaveElement.ScriptableSaveElement.IsComplete = playerSaveElement.IsComplete;
                    }
                }
            }
        }

        public static void DeleteProgress()
        {
            List<SaveScriptable> gameProgressElements = LoadGameProgressElements();
            foreach (SaveScriptable gameSaveElement in gameProgressElements)
            {
                gameSaveElement.ScriptableSaveElement.IsComplete = false;
            }
            
            SavePlayerProgressToPlayerPrefs();
        }

        public static void QuitGame()
        {
            SavePlayerProgressToPlayerPrefs();
            Application.Quit();
        }

        private static List<SaveScriptable> LoadGameProgressElements()
        {
            List<SaveScriptable> allSaveScriptables = new List<SaveScriptable>();
            
            string[] folders = { "SaveScriptables", "SaveScriptables/Badges", "SaveScriptables/MiniGames" };
            
            foreach (string folder in folders)
            {
                allSaveScriptables.AddRange(Resources.LoadAll<SaveScriptable>(folder));
            }
            
            return allSaveScriptables;
        }
        
        #endregion

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