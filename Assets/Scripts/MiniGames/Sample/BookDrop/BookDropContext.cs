using CIRC.MiniGames.Core.Interfaces;
using CIRC.Progression;

namespace CIRC.MiniGames.Sample
{
    public struct BookDropContext : IMiniGameContext
    {
        public MiniGameDataHolder MiniGameData;
        public bool isArrived;
    }
}