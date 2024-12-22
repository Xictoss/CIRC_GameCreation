using CIRC.Core.MiniGames.Core.Interfaces;
using CIRC.Core.Progression.Core;

namespace CIRC.Core.MiniGames.Sample.TabagismeMaisonSecouer
{
    public struct TabagismeMaisonSecouerContext : IMiniGameContext
    {
        public MiniGameData MiniGameData;
        public Smoke[] smokes;
    }
}