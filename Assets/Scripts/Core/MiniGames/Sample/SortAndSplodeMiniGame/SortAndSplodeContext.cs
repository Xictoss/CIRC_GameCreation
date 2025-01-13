using CIRC.Core.MiniGames.Core.Interfaces;
using CIRC.Core.Progression.Core;

namespace CIRC.Core.MiniGames.Sample.SortAndSplodeMiniGame
{
    public struct SortAndSplodeContext : IMiniGameContext
    {
        public MiniGameDataHolder MiniGameData;
        public SortAndSplodeSpawner Spawner;
        public EntityManager EntityManager;
    }
}