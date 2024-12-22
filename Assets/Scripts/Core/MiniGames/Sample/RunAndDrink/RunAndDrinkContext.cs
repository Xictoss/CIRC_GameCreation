using CIRC.Core.MiniGames.Core.Interfaces;
using CIRC.Core.Progression.Core;

namespace CIRC.Core.MiniGames.Sample.RunAndDrink
{
    public struct RunAndDrinkContext : IMiniGameContext
    {
        public MiniGameDataHolder MiniGameData;
        public int remainingDrinks;
    }
}