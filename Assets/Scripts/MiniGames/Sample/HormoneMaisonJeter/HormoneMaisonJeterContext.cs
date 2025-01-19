using CIRC.MiniGames.Core.Interfaces;
using CIRC.Progression;

namespace CIRC.MiniGames.Sample
{
    public struct HormoneMaisonJeterContext : IMiniGameContext
    {
        public MiniGameDataHolder miniGameData;
        public PillsManager pillsManager;
    }
}