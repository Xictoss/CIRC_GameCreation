using CIRC.Core.MiniGames.Core;
using CIRC.Core.MiniGames.Core.Interfaces;
using CIRC.Core.Progression.Core;
using UnityEngine;

namespace CIRC.Core.MiniGames.Sample.RunAndDrink
{
    public class RunAndDrinkHandler : MonoBehaviour, IMiniGameHandler<RunAndDrinkContext>
    {
        [SerializeField] private MiniGameDataHolder miniGameData;
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
                MiniGameData = miniGameData,
                remainingDrinks = _animalRun.RemainingDrinks,
            };
        }
    }
}