using CIRC.Core.MiniGames.Core.Interfaces;
using CIRC.Core.Progression.Core.Data;

namespace CIRC.Core.MiniGames.Sample.Core.MiniGames.Sample.PipePuzzle
{
    public struct PipePuzzleContext : IMiniGameContext
    {
        public MiniGameDataOLD MiniGameDataOld;
        public RotatingPiece[] pipes;
    }
}