using CIRC.MiniGames.Core.Interfaces;
using CIRC.Progression;

namespace CIRC.MiniGames.Sample
{
    public struct HydratationMaisonCanalisationContext : IMiniGameContext
    {
        public MiniGameDataHolder MiniGameData;
        public RotatingPiece[] pipes;
    }
}