using CIRC.MiniGames.Core;
using CIRC.MiniGames.Core.Interfaces;
using CIRC.Progression;
using UnityEngine;

namespace CIRC.MiniGames.Sample
{
    public class AlccolPlageCocktailHandler : MonoBehaviour, IMiniGameHandler<BookDropContext>
    {
        [SerializeField] private MiniGameDataHolder miniGameData;
        [SerializeField] private Water water;

        private BookDrop miniGame;

        private void Start()
        {
            miniGame = new BookDrop();
            MiniGameManager.Instance.StartMiniGame(miniGame, this);
        }

        public BookDropContext GetContext()
        {
            return new BookDropContext
            {
                MiniGameData = miniGameData,
                isArrived = water.IsArrived,
            };
        }
    }
}