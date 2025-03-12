using CIRC.MiniGames.Core.Interfaces;
using CIRC.Progression;

namespace CIRC.MiniGames.Sample
{
    public struct HydratationMaisonLabyrintheContext : IMiniGameContext
    {
        public MiniGameDataHolder MiniGameData;
        public int remainingDrinks;
    }
}