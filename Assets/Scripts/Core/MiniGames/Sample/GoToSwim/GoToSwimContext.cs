using CIRC.Core.MiniGames.Core.Interfaces;
using CIRC.Core.Progression.Core.Data;

namespace CIRC.Core.MiniGames.Sample.GoToSwim
{
    public struct GoToSwimContext : IMiniGameContext
    {
        public MiniGameDataOLD MiniGameDataOld;
        public bool isArrived;
    }
}