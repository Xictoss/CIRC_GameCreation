using CIRC.MiniGames.Core;
using CIRC.MiniGames.Core.Interfaces;
using CIRC.Progression;
using UnityEngine;

namespace CIRC.MiniGames.Sample
{
    public class ActiviteMaisonMagazineHandler : MonoBehaviour, IMiniGameHandler<ActiviteMaisonMagazineContext>
    {
        [SerializeField] private MiniGameDataHolder miniGameData;
        [SerializeField] private Book book;

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
                isArrived = book.IsArrived,
            };
        }
    }
}