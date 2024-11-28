using CIRC.Core.MiniGames.Core.Interfaces;
using CIRC.Core.Scriptables.Core;

namespace CIRC.Core.MiniGames.Sample.RunAndDrink
{
    public struct RunAndDrinkContext : IMiniGameContext
    {
        public MiniGameData miniGameData;
        public int remainingDrinks;
    }
}