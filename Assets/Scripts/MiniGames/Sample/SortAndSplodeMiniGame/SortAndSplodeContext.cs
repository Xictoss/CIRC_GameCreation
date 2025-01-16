using CIRC.MiniGames.Core.Interfaces;
using CIRC.Progression;

namespace CIRC.MiniGames.Sample
{
    public struct SortAndSplodeContext : IMiniGameContext
    {
        public MiniGameDataHolder MiniGameData;
        public SortAndSplodeSpawner Spawner;
        public EntityManager EntityManager;
    }
}