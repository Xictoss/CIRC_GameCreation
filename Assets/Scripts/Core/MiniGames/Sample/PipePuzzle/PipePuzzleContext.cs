using CIRC.Core.MiniGames.Core.Interfaces;
using CIRC.Core.Progression.Core;

namespace CIRC.Core.MiniGames.Sample.Core.MiniGames.Sample.PipePuzzle
{
    public struct PipePuzzleContext : IMiniGameContext
    {
        public MiniGameDataHolder MiniGameData;
        public RotatingPiece[] pipes;
    }
}