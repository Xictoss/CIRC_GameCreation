using CIRC.Core.MiniGames.Core;
using CIRC.Core.MiniGames.Core.Interfaces;
using CIRC.Core.Progression.Core;
using UnityEngine;

namespace CIRC.Core.MiniGames.Sample.BookDrop
{
    public class BookDropHandler : MonoBehaviour, IMiniGameHandler<BookDropContext>
    {
        [SerializeField] private MiniGameDataHolder miniGameData;
        [SerializeField] private Book book;

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
                isArrived = book.IsArrived,
            };
        }
    }
}