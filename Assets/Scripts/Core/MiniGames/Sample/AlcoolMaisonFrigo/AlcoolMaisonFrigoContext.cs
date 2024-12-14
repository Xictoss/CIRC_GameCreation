using CIRC.Core.MiniGames.Core.Interfaces;
using CIRC.Core.Progression.Core.Data;

namespace CIRC.Core.MiniGames.Sample.AlcoolMaisonFrigo
{
    public struct AlcoolMaisonFrigoContext : IMiniGameContext
    {
        public MiniGameDataOLD MiniGameDataOld;
        public AlcoolMaisonFrigoChoose alcoolMaisonFrigoChoose;
    }
}