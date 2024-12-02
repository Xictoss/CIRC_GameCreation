using CIRC.Core.MiniGames.Core.Interfaces;
using CIRC.Core.Progression.Core.Data;

namespace CIRC.Core.MiniGames.Sample.SortAndSplodeMiniGame
{
    public struct SortAndSplodeContext : IMiniGameContext
    {
        public MiniGameData MiniGameData;
        public SortAndSplodeSpawner Spawner;
        public EntityManager EntityManager;
    }
}