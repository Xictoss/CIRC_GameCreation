using CIRC.MiniGames.Core.Interfaces;
using CIRC.Progression;

namespace CIRC.MiniGames.Sample
{
    public struct TvChannelContext : IMiniGameContext
    {
        public MiniGameDataHolder MiniGameData;

        public bool IsArrived;
    }
}