using System;
using System.Collections.Generic;
using CIRC.Core.Progression.Core;
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
            Application.targetFrameRate = 60;

            SceneController = new SceneController();
            Logger = new Logger();
            
            SetupTimeScale();
            //LoadPlayerProgressFromPlayerPrefsOLD();
            LoadProgress();
        }

        private static void UnLoad()
        {
            SaveProgress();
            //SavePlayerProgressToPlayerPrefsOLD();
        }

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
            List<MiniGameData> progress = SaveManager.Instance.GetAllMiniGameData();

            foreach (MiniGameData element in progress)
            {
                SaveManager.Instance.MarkMiniGameUncompleted(
                    element.MiniGameId,
                    element.BadgeDisplay,
                    element.GameSubject
                    );
            }
            
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