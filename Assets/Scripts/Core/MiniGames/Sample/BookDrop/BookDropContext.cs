using CIRC.Core.MiniGames.Core.Interfaces;
using CIRC.Core.Scriptables.Core;

namespace CIRC.Core.MiniGames.Sample.BookDrop
{
    public struct BookDropContext : IMiniGameContext
    {
        public MiniGameData miniGameData;
        public bool isArrived;
    }
}