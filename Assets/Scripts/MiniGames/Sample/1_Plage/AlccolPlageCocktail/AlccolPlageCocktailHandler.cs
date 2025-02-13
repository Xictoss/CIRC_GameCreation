using CIRC.MiniGames.Core;
using CIRC.MiniGames.Core.Interfaces;
using CIRC.Progression;
using UnityEngine;

namespace CIRC.MiniGames.Sample
{
    public class AlccolPlageCocktailHandler : MonoBehaviour, IMiniGameHandler<ActiviteMaisonMagazineContext>
    {
        [SerializeField] private MiniGameDataHolder miniGameData;
        [SerializeField] private Water water;

        private ActiviteMaisonMagazine miniGame;

        private void Start()
        {
            miniGame = new ActiviteMaisonMagazine();
            MiniGameManager.Instance.StartMiniGame(miniGame, this);
        }

        public ActiviteMaisonMagazineContext GetContext()
        {
            return new ActiviteMaisonMagazineContext
            {
                MiniGameData = miniGameData,
                isArrived = water.IsArrived,
            };
        }
    }
}