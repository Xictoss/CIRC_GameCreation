using CIRC.Core.Controllers;
using NaughtyAttributes;
using UnityEngine;

namespace CIRC.Core
{
    [CreateAssetMenu(fileName = "GameMetrics", menuName = "CIRC/GameMetrics")]
    public partial class GameMetrics : ScriptableObject
    {
        public static GameMetrics Global => GameController.Metrics;
        
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
        
        [field: SerializeField, Scene, Foldout("Scenes/MiniGames")]
        public int SortAndSplodeScene { get; private set; }
        [field: SerializeField, Scene, Foldout("Scenes/MiniGames")]
        public int RunAndDrinkScene { get; private set; }
        
        [field: SerializeField, Foldout("MiniGames/SortAndSplode")]
        public int SortAndSplode_SpawnNumber { get; private set; }
        [field: SerializeField, Foldout("MiniGames/SortAndSplode")]
        public float SortAndSplode_SpawnCooldown { get; private set; }
        
        [field: SerializeField, Foldout("MiniGames/RunAndDrink")]
        public int RunAndDrink_DrinksNumber { get; private set; }
    }
}