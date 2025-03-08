using DevLocker.Utils;
using NaughtyAttributes;
using UnityEngine;

namespace CIRC.Controllers
{
    [CreateAssetMenu(fileName = "GameMetrics", menuName = "CIRC/GameMetrics")]
    public partial class GameMetrics : ScriptableObject
    {
        public static GameMetrics Global => GameController.Metrics;

        #region Scenes
        
        [field: SerializeField, Foldout("Scenes")]
        public SceneReference MainMenuScene { get; private set; }
        
        [field: SerializeField, Foldout("Scenes/Levels")]
        public SceneReference PlageScene { get; private set; }
        [field: SerializeField, Foldout("Scenes/Levels")]
        public SceneReference MaisonScene { get; private set; }
        [field: SerializeField, Foldout("Scenes/Levels")]
        public SceneReference ParcScene { get; private set; }
        [field: SerializeField, Foldout("Scenes/Levels")]
        public SceneReference LotissementScene { get; private set; }
        [field: SerializeField, Foldout("Scenes/Levels")]
        public SceneReference EntrepriseScene { get; private set; }
        [field: SerializeField, Foldout("Scenes/Levels")]
        public SceneReference VilleScene { get; private set; }
        [field: SerializeField, Foldout("Scenes/Levels")]
        public SceneReference StadeUniversitaireScene { get; private set; }
        [field: SerializeField, Foldout("Scenes/Levels")]
        public SceneReference CliniqueScene { get; private set; }
        
        //Plage
        [field: SerializeField, Foldout("Scenes/MiniGames")]
        public SceneReference ActivitePlageNager { get; private set; }
        [field: SerializeField, Foldout("Scenes/MiniGames")]
        public SceneReference AlccolPlageCocktail { get; private set; }
        [field: SerializeField, Foldout("Scenes/MiniGames")]
        public SceneReference AlimentationPlageChips { get; private set; }
        [field: SerializeField, Foldout("Scenes/MiniGames")]
        public SceneReference HydratationPlageTourner { get; private set; }
        [field: SerializeField, Foldout("Scenes/MiniGames")]
        public SceneReference TabagismePlageCigarette { get; private set; }
        
        //Maison
        [field: SerializeField, Foldout("Scenes/MiniGames")]
        public SceneReference HydratationMaisonLabyrinthe { get; private set; }
        [field: SerializeField, Foldout("Scenes/MiniGames")]
        public SceneReference HydratationMaisonCanalisation { get; private set; }
        [field: SerializeField, Foldout("Scenes/MiniGames")]
        public SceneReference TabagismeMaisonSecouer { get; private set; }
        [field: SerializeField, Foldout("Scenes/MiniGames")]
        public SceneReference ActiviteMaisonMagazine { get; private set; }
        [field: SerializeField, Foldout("Scenes/MiniGames")]
        public SceneReference ActiviteMaisonTele { get; private set; }
        [field: SerializeField, Foldout("Scenes/MiniGames")]
        public SceneReference AlcoolMaisonFrigo { get; private set; }
        [field: SerializeField, Foldout("Scenes/MiniGames")]
        public SceneReference AlcoolMaisonBoisson { get; private set; }
        [field: SerializeField, Foldout("Scenes/MiniGames")]
        public SceneReference HormoneMaisonJeter { get; private set; }
        [field: SerializeField, Foldout("Scenes/MiniGames")]
        public SceneReference AlimentationMaisonRadio { get; private set; }
        
        //Entreprise
        [field: SerializeField, Foldout("Scenes/MiniGames")]
        public SceneReference ChimiqueEntrepriseTaper { get; private set; }
        [field: SerializeField, Foldout("Scenes/MiniGames")]
        public SceneReference ActiviteEntrepriseDrag { get; private set; }
        [field: SerializeField, Foldout("Scenes/MiniGames")]
        public SceneReference VaccinationEntrepriseDrag { get; private set; }
        
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

        #endregion MiniGameMetrics

    }
}