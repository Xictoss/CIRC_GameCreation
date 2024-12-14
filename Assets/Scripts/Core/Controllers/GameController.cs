using System;
using System.Collections.Generic;
using CIRC.Core.Progression.Core;
using CIRC.Core.Progression.Core.Core.Progression.Core;
using CIRC.Core.Progression.Core.Data;
using LTX.ChanneledProperties;
using PlasticPipe.PlasticProtocol.Messages;
using UnityEngine;

namespace CIRC.Core.Controllers
{
    public static class GameController
    {
        public static SaveData SaveData { get; private set; }
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
            Application.targetFrameRate = 60;

            SceneController = new SceneController();
            Logger = new Logger();
            
            SetupTimeScale();
            LoadPlayerProgressFromPlayerPrefsOLD();
        }

        private static bool UnLoad()
        {
            SavePlayerProgressToPlayerPrefsOLD();
            return true;
        }

        #region Progress Functions OLD
        
        public static void SavePlayerProgressToPlayerPrefsOLD()
        {
            Debug.Log("Saving player progress");
            
            List<SaveScriptable> gameProgressElements = LoadGameProgressElementsOLD();
            
            foreach (SaveScriptable progressElement in gameProgressElements)
            {
                SaveData.Write(progressElement.SaveElement);
            }

            ProgressionController.SaveProgressDataToPlayerPrefs(SaveData);
            ProgressionController.SaveProgressData(SaveData);
            
            GameSaved?.Invoke();
        }
        
        public static void LoadPlayerProgressFromPlayerPrefsOLD()
        {
            Debug.Log("Loading player progress");
            
            SaveData = ProgressionController.LoadProgressDataFromPlayerPrefs();
            //SaveData = ProgressionController.LoadProgressData();
            
            List<SaveScriptable> gameProgressElements = LoadGameProgressElementsOLD();

            foreach (SaveElement playerSaveElement in SaveData.PlayerProgression)
            {
                foreach (SaveScriptable gameSaveElement in gameProgressElements)
                {
                    if (playerSaveElement.GuidID == gameSaveElement.SaveElement.GuidID)
                    {
                        if (SaveData.SaveVersion == "0")
                        {
                            gameSaveElement.SaveElement.IsComplete = false;
                            Debug.LogError("NON");
                            continue;
                        }
                        gameSaveElement.SaveElement.IsComplete = playerSaveElement.IsComplete;
                    }
                }
            }
        }

        public static void DeleteProgressOLD()
        {
            List<SaveScriptable> gameProgressElements = LoadGameProgressElementsOLD();
            foreach (SaveScriptable gameSaveElement in gameProgressElements)
            {
                gameSaveElement.SaveElement.IsComplete = false;
            }
            
            SavePlayerProgressToPlayerPrefsOLD();
        }

        private static List<SaveScriptable> LoadGameProgressElementsOLD()
        {
            List<SaveScriptable> allSaveScriptables = new List<SaveScriptable>();
            
            string[] folders = { "SaveScriptables", "SaveScriptables/Badges", "SaveScriptables/MiniGames" };
            
            foreach (string folder in folders)
            {
                allSaveScriptables.AddRange(Resources.LoadAll<SaveScriptable>(folder));
            }
            
            return allSaveScriptables;
        }
        
        public static void QuitGameOLD()
        {
            SavePlayerProgressToPlayerPrefsOLD();
            Application.Quit();
        }
        
        #endregion
        
        #region Progress Functions
        
        public static void SaveProgress()
        {
            Debug.Log("Saving player progress");
            
            SaveManager.Instance.SaveData();
            
            GameSaved?.Invoke();
        }
        
        public static void LoadProgress()
        {
            Debug.Log("Loading player progress");
            
            SaveManager.Instance.LoadData();
        }

        public static void DeleteProgress()
        {
            SaveProgress();
        }
        
        public static void QuitGame()
        {
            SaveProgress();
            UnLoad();
            Application.Quit();
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