
using CIRC.MiniGames.Core;
using CIRC.MiniGames.Core.Interfaces;
using CIRC.Progression;
using UnityEngine;

namespace CIRC.MiniGames.Sample
{
    public class LimiterCliniqueDragHandler : MonoBehaviour, IMiniGameHandler<LimiterCliniqueDragContext>
    {
        [SerializeField] private MiniGameDataHolder miniGameData;
        [SerializeField] private Medicals medicals;
        
        private LimiterCliniqueDrag miniGame;
        
        private void Start()
        {
            miniGame = new LimiterCliniqueDrag();
            MiniGameManager.Instance.StartMiniGame(miniGame, this);
        }
        
        public LimiterCliniqueDragContext GetContext()
        {
            return new LimiterCliniqueDragContext
            {
                miniGameData = miniGameData,
                isGood = medicals.isGood
            };
        }
    }
}