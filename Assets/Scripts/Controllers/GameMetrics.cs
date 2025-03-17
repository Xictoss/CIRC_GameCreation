using CIRC.SceneManagement;
using DevLocker.Utils;
using NaughtyAttributes;
using UnityEngine;

namespace CIRC.Controllers
{
    [CreateAssetMenu(fileName = "GameMetrics", menuName = "CIRC/GameMetrics")]
    public partial class GameMetrics : ScriptableObject
    {
        public static GameMetrics Global => GameController.Metrics;
        [field : SerializeField] public SceneLoader SceneLoader { get; private set; }

        #region Scenes
        
        [field: SerializeField, Foldout("Scenes")]
        public SceneReference MainMenuScene { get; private set; }
        
        [field: SerializeField, Foldout("Scenes/Levels")]
        public SceneReference PlageScene { get; private set; }
        [field: SerializeField, Foldout("Scenes/Levels")]
        public SceneReference MaisonScene { get; private set; }
        [field: SerializeField, Foldout("Scenes/Levels")]
        public SceneReference LotissementScene { get; private set; }
        [field: SerializeField, Foldout("Scenes/Levels")]
        public SceneReference EntrepriseScene { get; private set; }
        [field: SerializeField, Foldout("Scenes/Levels")]
        public SceneReference VilleScene { get; private set; }
        [field: SerializeField, Foldout("Scenes/Levels")]
        public SceneReference CliniqueScene { get; private set; }
        
        #endregion

        #region SceneNames

        [field: SerializeField, Foldout("Scene Names")]
        public string[] SceneNames { get; private set; }
        
        #endregion

        #region Menu Names
        
        [field: SerializeField, Foldout("Menu Names")]
        public string BadgeDisplayer { get; private set; }
        [field: SerializeField, Foldout("Menu Names")]
        public string MiniGamePopUpMenu { get; private set; }
        [field: SerializeField, Foldout("Menu Names")]
        public string MiniGameReward { get; private set; }
        [field: SerializeField, Foldout("Menu Names")]
        public string BooksMenu { get; private set; }
        [field: SerializeField, Foldout("Menu Names")]
        public string LevelsMenu { get; private set; }
        [field: SerializeField, Foldout("Menu Names")]
        public string MiniGamesMenu { get; private set; }
        [field: SerializeField, Foldout("Menu Names")]
        public string SettingsMenu { get; private set; }
        [field: SerializeField, Foldout("Menu Names")]
        public string PauseMenu { get; private set; }

        #endregion
        
        #region MiniGameMetrics
        
        [field: SerializeField, Foldout("MiniGames/SortAndSplode")]
        public int SortAndSplode_SpawnNumber { get; private set; }
        [field: SerializeField, Foldout("MiniGames/SortAndSplode")]
        public float SortAndSplode_SpawnCooldown { get; private set; }
        
        [field: SerializeField, Foldout("MiniGames/RunAndDrink")]
        public int RunAndDrink_DrinksNumber { get; private set; }
        
        [field: SerializeField, Foldout("MiniGames/ActivitePlageNager")]
        public int APN_GuySpeed { get; private set; }
        
        [field: SerializeField, Foldout("MiniGames/HydratationPlageTourner")]
        public float HPT_fillSpeed { get; private set; }
        
        [field: SerializeField, Foldout("MiniGames/ActiviteLotissementTaper")]
        public float ALT_GuyToMotivateSpeed { get; private set; }
        
        [field: SerializeField, Foldout("MiniGames/ActiviteVilleTaper")]

        public float AVT_BikeSpeed { get; private set; }

        #endregion MiniGameMetrics

    }
}