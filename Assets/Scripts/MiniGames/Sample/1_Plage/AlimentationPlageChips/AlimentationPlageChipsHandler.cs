
using CIRC.MiniGames.Core;
using CIRC.MiniGames.Core.Interfaces;
using CIRC.Progression;
using UnityEngine;

namespace CIRC.MiniGames.Sample
{
    public class AlimentationPlageChipsHandler : MonoBehaviour, IMiniGameHandler<AlimentationPlageChipsContext>
    {
        [SerializeField] private MiniGameDataHolder miniGameData;
        [SerializeField] private Hand hand;
        
        private AlimentationPlageChips miniGame;
        
        private void Start()
        {
            miniGame = new AlimentationPlageChips();
            MiniGameManager.Instance.StartMiniGame(miniGame, this);
        }
        
        public AlimentationPlageChipsContext GetContext()
        {
            return new AlimentationPlageChipsContext
            {
                miniGameData = miniGameData,
                isFinish = hand.isFinished
            };
        }
    }
}