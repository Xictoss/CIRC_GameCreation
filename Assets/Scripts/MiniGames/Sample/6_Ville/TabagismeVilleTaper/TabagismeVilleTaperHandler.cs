
using CIRC.MiniGames.Core;
using CIRC.MiniGames.Core.Interfaces;
using CIRC.Progression;
using UnityEngine;

namespace CIRC.MiniGames.Sample
{
    public class TabagismeVilleTaperHandler : MonoBehaviour, IMiniGameHandler<TabagismeVilleTaperContext>
    {
        [SerializeField] private MiniGameDataHolder miniGameData;
        [SerializeField] private CigarettePack _cigarettePack;
        
        private TabagismeVilleTaper miniGame;
        
        private void Start()
        {
            miniGame = new TabagismeVilleTaper();
            MiniGameManager.Instance.StartMiniGame(miniGame, this);
        }
        
        public TabagismeVilleTaperContext GetContext()
        {
            return new TabagismeVilleTaperContext
            {
                miniGameData = miniGameData,
                isFall = _cigarettePack.isFall
            };
        }
    }
}