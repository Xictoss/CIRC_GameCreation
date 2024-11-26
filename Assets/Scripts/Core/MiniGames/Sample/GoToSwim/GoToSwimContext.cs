using CIRC.Core.MiniGames.Core.Interfaces;
using CIRC.Core.Scriptables.Core;

namespace CIRC.Core.MiniGames.Sample.GoToSwim
{
    public struct GoToSwimContext : IMiniGameContext
    {
        public MiniGameData miniGameData;
        public bool isArrived;
    }
}