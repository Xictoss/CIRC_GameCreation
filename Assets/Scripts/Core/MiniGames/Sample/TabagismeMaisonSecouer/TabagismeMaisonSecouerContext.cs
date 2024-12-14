using CIRC.Core.MiniGames.Core.Interfaces;
using CIRC.Core.Progression.Core.Data;

namespace CIRC.Core.MiniGames.Sample.TabagismeMaisonSecouer
{
    public struct TabagismeMaisonSecouerContext : IMiniGameContext
    {
        public MiniGameDataOLD MiniGameDataOld;
        public Smoke[] smokes;
    }
}