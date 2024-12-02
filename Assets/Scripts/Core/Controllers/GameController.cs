using System;
using System.Collections.Generic;
using CIRC.Core.Progression.Core;
using CIRC.Core.Progression.Core.Data;
using LTX.ChanneledProperties;
using UnityEngine;

namespace CIRC.Core.Controllers
{
    public static class GameController
    {
        public static Logger Logger { get; private set; }
        public static SceneController SceneController { get; private set; }
        private static GameMetrics gameMetrics;
        public static GameMetrics Metrics
        {
            get
            {
                if (!gameMetrics)
                    gameMetrics = Resources.Load<GameMetrics>("GameMetrics");

                return gameMetrics;
            }
        }
        
        #region PrioritisedProperties

        public static PrioritisedProperty<float> TimeScale { get; private set; }

        #endregion

        public static event Action GameSaved;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void Load()
        {
            Application.wantsToQuit += UnLoad;
            Application.targetFrameRate = 60;

            SceneController = new SceneController();
            Logger = new Logger();
            
            SetupTimeScale();
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
                dataToSave.Write(progressElement.saveElement);
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
                    if (playerSaveElement.guidID == gameSaveElement.saveElement.guidID)
                    {
                        if (playerProgressData.SaveVersion == "0")
                        {
                            gameSaveElement.saveElement.isComplete = false;
                            continue;
                        }
                        gameSaveElement.saveElement.isComplete = playerSaveElement.isComplete;
                    }
                }
            }
        }

        public static void DeleteProgress()
        {
            List<SaveScriptable> gameProgressElements = LoadGameProgressElements();
            foreach (SaveScriptable gameSaveElement in gameProgressElements)
            {
                gameSaveElement.saveElement.isComplete = false;
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

        #region Prioritised Properties

        private static void SetupTimeScale()
        {
            TimeScale = new PrioritisedProperty<float>(1f);
            
            TimeScale.AddOnValueChangeCallback(UpdateTimeScale, true);
        }

        private static void UpdateTimeScale(float value)
        {
            Time.timeScale = value;
        }

        #endregion
    }
}