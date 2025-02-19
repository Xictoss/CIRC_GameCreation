
using CIRC.MiniGames.Core.Interfaces;
using CIRC.Progression;

namespace CIRC.MiniGames.Sample
{
    public struct ActiviteLotissementDragContext : IMiniGameContext
    {
        public MiniGameDataHolder miniGameData;
        public bool isFinished;
    }
}