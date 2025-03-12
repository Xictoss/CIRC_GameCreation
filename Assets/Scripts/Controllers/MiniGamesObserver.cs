using CIRC.Progression;
using UnityEngine;

namespace CIRC.Controllers
{
    public class MiniGamesObserver
    {
        public MiniGameDataHolder[] miniGames { get; private set; }
        
        public MiniGamesObserver()
        {
            miniGames = Resources.LoadAll<MiniGameDataHolder>("Games");
        }
    }
}