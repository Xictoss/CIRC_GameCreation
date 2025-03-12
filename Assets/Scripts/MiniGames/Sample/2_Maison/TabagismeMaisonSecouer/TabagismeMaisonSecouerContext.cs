using CIRC.MiniGames.Core.Interfaces;
using CIRC.MiniGames.Sample;
using CIRC.Progression;

namespace CIRC.MiniGames.Sample
{
    public struct TabagismeMaisonSecouerContext : IMiniGameContext
    {
        public MiniGameDataHolder MiniGameData;
        public Smoke[] smokes;
    }
}