using CIRC.Core.MiniGames.Core.Interfaces;
using CIRC.Core.Progression.Core;

namespace CIRC.Core.MiniGames.Sample.GoToSwim
{
    public struct GoToSwimContext : IMiniGameContext
    {
        public MiniGameDataHolder MiniGameData;
        public bool isArrived;
    }
}