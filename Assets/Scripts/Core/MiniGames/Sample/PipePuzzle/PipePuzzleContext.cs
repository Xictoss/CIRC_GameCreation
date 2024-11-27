using CIRC.Core.MiniGames.Core.Interfaces;
using CIRC.Core.Scriptables.Core;

namespace CIRC.Core.MiniGames.Sample.Core.MiniGames.Sample.PipePuzzle
{
    public struct PipePuzzleContext : IMiniGameContext
    {
        public MiniGameData miniGameData;
        public RotatingPiece[] pipes;
    }
}