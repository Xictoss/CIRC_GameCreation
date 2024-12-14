using CIRC.Core.MiniGames.Core;
using CIRC.Core.MiniGames.Core.Interfaces;
using CIRC.Core.Progression.Core.Data;
using UnityEngine;
using UnityEngine.Serialization;

namespace CIRC.Core.MiniGames.Sample.BookDrop
{
    public class BookDropHandler : MonoBehaviour, IMiniGameHandler<BookDropContext>
    {
        [FormerlySerializedAs("miniGameData")] [SerializeField] private MiniGameDataOLD miniGameDataOld;
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
                MiniGameDataOld = miniGameDataOld,
                isArrived = book.IsArrived,
            };
        }
    }
}