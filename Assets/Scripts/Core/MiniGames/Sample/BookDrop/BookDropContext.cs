using CIRC.Core.MiniGames.Core.Interfaces;
using CIRC.Core.Progression.Core;

namespace CIRC.Core.MiniGames.Sample.BookDrop
{
    public struct BookDropContext : IMiniGameContext
    {
        public MiniGameDataHolder MiniGameData;
        public bool isArrived;
    }
}