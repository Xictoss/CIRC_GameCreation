using CIRC.Core.MiniGames.Core.Interfaces;
using CIRC.Core.Progression.Core;

namespace CIRC.Core.MiniGames.Sample.AlcoolMaisonFrigo
{
    public struct AlcoolMaisonFrigoContext : IMiniGameContext
    {
        public MiniGameData MiniGameData;
        public AlcoolMaisonFrigoChoose alcoolMaisonFrigoChoose;
    }
}