using CIRC.Core.MiniGames.Sample.RunAndDrink;
using CIRC.MiniGames.Core;
using CIRC.MiniGames.Core.Interfaces;
using CIRC.Progression;
using UnityEngine;

namespace CIRC.MiniGames.Sample
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