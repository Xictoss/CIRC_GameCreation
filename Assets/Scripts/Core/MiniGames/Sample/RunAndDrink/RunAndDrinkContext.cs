using CIRC.Core.MiniGames.Core.Interfaces;
using CIRC.Core.Progression.Core.Data;

namespace CIRC.Core.MiniGames.Sample.RunAndDrink
{
    public struct RunAndDrinkContext : IMiniGameContext
    {
        public MiniGameDataOLD MiniGameDataOld;
        public int remainingDrinks;
    }
}