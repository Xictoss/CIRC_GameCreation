
using CIRC.MiniGames.Core;
using CIRC.MiniGames.Core.Interfaces;
using CIRC.Progression;
using UnityEngine;

namespace CIRC.MiniGames.Sample
{
    public class TabagismeVilleDragHandler : MonoBehaviour, IMiniGameHandler<TabagismeVilleDragContext>
    {
        [SerializeField] private MiniGameDataHolder miniGameData;
        
        private TabagismeVilleDrag miniGame;
        
        private void Start()
        {
            miniGame = new TabagismeVilleDrag();
            MiniGameManager.Instance.StartMiniGame(miniGame, this);
        }
        
        public TabagismeVilleDragContext GetContext()
        {
            return new TabagismeVilleDragContext
            {
                miniGameData = miniGameData,
            };
        }
    }
}