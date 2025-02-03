using CIRC.MiniGames.Core;
using CIRC.MiniGames.Core.Interfaces;
using CIRC.Progression;
using UnityEngine;

namespace CIRC.MiniGames.Sample
{
    public class HydratationMaisonLabyrintheHandler : MonoBehaviour, IMiniGameHandler<HydratationMaisonLabyrintheContext>
    {
        [SerializeField] private MiniGameDataHolder miniGameData;
        [SerializeField] private AnimalRun _animalRun;

        private HydratationMaisonLabyrinthe miniGame;
        private void Start()
        {
            miniGame = new HydratationMaisonLabyrinthe();
            MiniGameManager.Instance.StartMiniGame(miniGame, this);
        }

        public HydratationMaisonLabyrintheContext GetContext()
        {
            return new HydratationMaisonLabyrintheContext
            {
                MiniGameData = miniGameData,
                remainingDrinks = _animalRun.RemainingDrinks,
            };
        }
    }
}