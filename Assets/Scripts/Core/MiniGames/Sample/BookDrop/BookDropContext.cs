using CIRC.Core.MiniGames.Core.Interfaces;
using CIRC.Core.Progression.Core.Data;

namespace CIRC.Core.MiniGames.Sample.BookDrop
{
    public struct BookDropContext : IMiniGameContext
    {
        public MiniGameData miniGameData;
        public bool isArrived;
    }
}