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

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void Load()
        {
            Application.quitting += UnLoad;
            
            ExampleUseOfPrioritisedProperty();
            LoadPlayerProgress();
        }
        
        private static void UnLoad()
        {
            SavePlayerProgress();
        }

        private static void SavePlayerProgress()
        {
            Debug.Log("Saving player progress");
            
            SaveData dataToSave = new SaveData(Application.version);
            List<SaveScriptable> gameProgressElements = LoadGameProgressElements();
            
            foreach (SaveScriptable progressElement in gameProgressElements)
            {
                dataToSave.Write(progressElement.scriptableSaveElement);
            }

            ProgressionController.SaveProgressData(dataToSave);
        }

        private static void LoadPlayerProgress()
        {
            Debug.Log("Loading player progress");
            
            SaveData playerProgressData = ProgressionController.LoadProgressData();
            List<SaveScriptable> gameProgressElements = LoadGameProgressElements();

            foreach (SaveElement playerSaveElement in playerProgressData.PlayerProgression)
            {
                foreach (SaveScriptable gameSaveElement in gameProgressElements)
                {
                    if (playerSaveElement.guidID == gameSaveElement.scriptableSaveElement.guidID && playerSaveElement.isComplete)
                    {
                        gameSaveElement.saveElementName = "PlayerDoneThis";
                    }
                }
            }
        }

        private static List<SaveScriptable> LoadGameProgressElements()
        {
            return new List<SaveScriptable>(Resources.LoadAll<SaveScriptable>("GameScriptables"));
        }

        private static void ExampleUseOfPrioritisedProperty()
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
    }
}