
using CIRC.MiniGames.Core;
using CIRC.MiniGames.Core.Interfaces;
using CIRC.Progression;
using UnityEngine;

namespace CIRC.MiniGames.Sample
{
    public class ExpositionVilleDragHandler : MonoBehaviour, IMiniGameHandler<ExpositionVilleDragContext>
    {
        [SerializeField] private MiniGameDataHolder miniGameData;
        [SerializeField] private Hat _hat;
        
        private ExpositionVilleDrag miniGame;
        
        private void Start()
        {
            miniGame = new ExpositionVilleDrag();
            MiniGameManager.Instance.StartMiniGame(miniGame, this);
        }
        
        public ExpositionVilleDragContext GetContext()
        {
            return new ExpositionVilleDragContext
            {
                miniGameData = miniGameData,
                isFinished = _hat.isArrived
            };
        }
    }
}