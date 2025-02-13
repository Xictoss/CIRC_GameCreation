
using CIRC.MiniGames.Core.Interfaces;
using CIRC.Progression;

namespace CIRC.MiniGames.Sample
{
    public struct ActiviteEntrepriseDragContext : IMiniGameContext
    {
        public MiniGameDataHolder miniGameData;
        public Poster[] posters;
    }
}