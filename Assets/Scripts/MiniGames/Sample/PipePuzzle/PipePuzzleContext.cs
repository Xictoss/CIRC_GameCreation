using CIRC.MiniGames.Core.Interfaces;
using CIRC.Progression;

namespace CIRC.MiniGames.Sample
{
    public struct PipePuzzleContext : IMiniGameContext
    {
        public MiniGameDataHolder MiniGameData;
        public RotatingPiece[] pipes;
    }
}