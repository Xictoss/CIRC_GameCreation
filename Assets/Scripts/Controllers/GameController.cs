using System.Collections.Generic;
using CIRC.CameraScripts;
using CIRC.Progression;
using LTX.ChanneledProperties;
using SaveSystem.Core;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CIRC.Controllers
{
    public static class GameController
    {
        public static Logger Logger { get; private set; }
        public static ProgressionManager ProgressionManager { get; private set; }
        public static CameraController CameraController { get; private set; }
        public static MiniGameRegister MiniGameRegister { get; private set; }
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
        
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void Load()
        {
            Application.targetFrameRate = 60;

            SceneController = new SceneController();
            Logger = new Logger();

            MiniGameRegister = new MiniGameRegister();
            SceneManager.sceneLoaded += MiniGameRegister.OnSceneChanged;
            CameraController = new CameraController();
            
            ProgressionManager = new ProgressionManager();
            Save.AddListener(ProgressionManager);
            Save.SetSaveManager(new PlayerPrefsSaveManager());
            
            SetupTimeScale();
            LoadProgress();
        }

        private static void UnLoad()
        {
            SaveProgress();
            Save.RemoveListener(ProgressionManager);
        }

        #region Progress Functions
        
        public static void SaveProgress()
        {
            Debug.Log("Saving player progress");
            Save.Push<GameSave, GameSaveSettings>(new GameSaveSettings()
            {
                prefName = "Player"
            });
        }
        
        private static void LoadProgress()
        {
            Debug.Log("Loading player progress");
            Save.Pull<GameSave, GameSaveSettings>(out _, new GameSaveSettings()
            {
                prefName = "Player"
            });
        }
        
        public static void ResetProgression()
        {
            foreach (KeyValuePair<string, bool> game in ProgressionManager.miniGameStatus)
            {
                ProgressionManager.ResetMiniGame(game.Key);
            }
            
            SaveProgress();
        }
        
        public static void QuitGame()
        {
            UnLoad();
            Application.Quit();
        }
        
        #endregion

        #region Prioritised Properties

        public static PrioritisedProperty<float> TimeScale { get; private set; }
        
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