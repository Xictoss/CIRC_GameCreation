using CIRC.MiniGames.Core.Interfaces;
using CIRC.Progression;

namespace CIRC.Core.MiniGames.Sample.RunAndDrink
{
    public struct RunAndDrinkContext : IMiniGameContext
    {
        public MiniGameDataHolder MiniGameData;
        public int remainingDrinks;
    }
}