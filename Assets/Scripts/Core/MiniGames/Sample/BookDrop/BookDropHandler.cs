using CIRC.Core.MiniGames.Core;
using CIRC.Core.MiniGames.Core.Interfaces;
using CIRC.Core.Scriptables.Core;
using UnityEngine;

namespace CIRC.Core.MiniGames.Sample.BookDrop
{
    public class BookDropHandler : MonoBehaviour, IMiniGameHandler<BookDropContext>
    {
        [SerializeField] private MiniGameData miniGameData;

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
                miniGameData = miniGameData
            };
        }
    }
}