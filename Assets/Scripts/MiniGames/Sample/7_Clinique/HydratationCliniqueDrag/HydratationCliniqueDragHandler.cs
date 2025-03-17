
using CIRC.MiniGames.Core;
using CIRC.MiniGames.Core.Interfaces;
using CIRC.Progression;
using UnityEngine;

namespace CIRC.MiniGames.Sample
{
    public class HydratationCliniqueDragHandler : MonoBehaviour, IMiniGameHandler<HydratationCliniqueDragContext>
    {
        [SerializeField] private MiniGameDataHolder miniGameData;
        [SerializeField] private Drink drink;
        
        private HydratationCliniqueDrag miniGame;
        
        private void Start()
        {
            miniGame = new HydratationCliniqueDrag();
            MiniGameManager.Instance.StartMiniGame(miniGame, this);
        }
        
        public HydratationCliniqueDragContext GetContext()
        {
            return new HydratationCliniqueDragContext
            {
                miniGameData = miniGameData,
                isRight = drink.isRight
            };
        }
    }
}