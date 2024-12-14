using CIRC.Core.MiniGames.Core;
using CIRC.Core.MiniGames.Core.Interfaces;
using CIRC.Core.Progression.Core.Data;
using UnityEngine;
using UnityEngine.Serialization;

namespace CIRC.Core.MiniGames.Sample.RunAndDrink
{
    public class RunAndDrinkHandler : MonoBehaviour, IMiniGameHandler<RunAndDrinkContext>
    {
        [FormerlySerializedAs("_miniGameData")] [SerializeField] private MiniGameDataOLD miniGameDataOld;
        [SerializeField] private AnimalRun _animalRun;

        private RunAndDrink miniGame;
        private void Start()
        {
            miniGame = new RunAndDrink();
            MiniGameManager.Instance.StartMiniGame(miniGame, this);
        }

        public RunAndDrinkContext GetContext()
        {
            return new RunAndDrinkContext
            {
                MiniGameDataOld = miniGameDataOld,
                remainingDrinks = _animalRun.RemainingDrinks,
            };
        }
    }
}