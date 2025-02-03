using NaughtyAttributes;
using UnityEngine;

namespace CIRC.Controllers
{
    [CreateAssetMenu(fileName = "GameMetrics", menuName = "CIRC/GameMetrics")]
    public partial class GameMetrics : ScriptableObject
    {
        public static GameMetrics Global => GameController.Metrics;

        #region Scenes
        
        [field: SerializeField, Scene, Foldout("Scenes")]
        public int MainMenuScene { get; private set; }
        
        [field: SerializeField, Scene, Foldout("Scenes/Levels")]
        public int PlageScene { get; private set; }
        [field: SerializeField, Scene, Foldout("Scenes/Levels")]
        public int MaisonScene { get; private set; }
        [field: SerializeField, Scene, Foldout("Scenes/Levels")]
        public int ParcScene { get; private set; }
        [field: SerializeField, Scene, Foldout("Scenes/Levels")]
        public int LotissementScene { get; private set; }
        [field: SerializeField, Scene, Foldout("Scenes/Levels")]
        public int EntrepriseScene { get; private set; }
        [field: SerializeField, Scene, Foldout("Scenes/Levels")]
        public int VilleScene { get; private set; }
        [field: SerializeField, Scene, Foldout("Scenes/Levels")]
        public int StadeUniversitaireScene { get; private set; }
        [field: SerializeField, Scene, Foldout("Scenes/Levels")]
        public int CliniqueScene { get; private set; }
        
        //Plage
        [field: SerializeField, Scene, Foldout("Scenes/MiniGames")]
        public int ActivitePlageNager { get; private set; }
        [field: SerializeField, Scene, Foldout("Scenes/MiniGames")]
        public int AlccolPlageCocktail { get; private set; }
        
        //Maison
        [field: SerializeField, Scene, Foldout("Scenes/MiniGames")]
        public int HydratationMaisonLabyrinthe { get; private set; }
        [field: SerializeField, Scene, Foldout("Scenes/MiniGames")]
        public int HydratationMaisonCanalisation { get; private set; }
        [field: SerializeField, Scene, Foldout("Scenes/MiniGames")]
        public int TabagismeMaisonSecouer { get; private set; }
        [field: SerializeField, Scene, Foldout("Scenes/MiniGames")]
        public int ActiviteMaisonMagazine { get; private set; }
        [field: SerializeField, Scene, Foldout("Scenes/MiniGames")]
        public int ActiviteMaisonTele { get; private set; }
        [field: SerializeField, Scene, Foldout("Scenes/MiniGames")]
        public int AlcoolMaisonFrigo { get; private set; }
        [field: SerializeField, Scene, Foldout("Scenes/MiniGames")]
        public int AlcoolMaisonBoisson { get; private set; }
        [field: SerializeField, Scene, Foldout("Scenes/MiniGames")]
        public int HormoneMaisonJeter { get; private set; }
        [field: SerializeField, Scene, Foldout("Scenes/MiniGames")]
        public int AlimentationMaisonRadio { get; private set; }
        
        //Entreprise
        [field: SerializeField, Scene, Foldout("Scenes/MiniGames")]
        public int ChimiqueEntrepriseTaper { get; private set; }
        [field: SerializeField, Scene, Foldout("Scenes/MiniGames")]
        public int ActiviteEntrepriseDrag { get; private set; }
        [field: SerializeField, Scene, Foldout("Scenes/MiniGames")]
        public int VaccinationEntrepriseDrag { get; private set; }
        
        #endregion

        #region Menu Names

        [field: SerializeField, Foldout("Menu Names")]
        public string MiniGamePopUpMenu { get; private set; }
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
        
        [field: SerializeField, Foldout("MiniGames/SortAndSplode")]
        public int SortAndSplode_SpawnNumber { get; private set; }
        [field: SerializeField, Foldout("MiniGames/SortAndSplode")]
        public float SortAndSplode_SpawnCooldown { get; private set; }
        
        [field: SerializeField, Foldout("MiniGames/RunAndDrink")]
        public int RunAndDrink_DrinksNumber { get; private set; }
    }
}