
using CIRC.MiniGames.Core;
using CIRC.MiniGames.Core.Interfaces;
using CIRC.Progression;
using UnityEngine;

namespace CIRC.MiniGames.Sample
{
    public class HydrationPlageTaperHandler : MonoBehaviour, IMiniGameHandler<HydrationPlageTaperContext>
    {
        [SerializeField] private MiniGameDataHolder miniGameData;
        [SerializeField] private Buvoir buvoir;
        
        private HydrationPlageTaper miniGame;
        
        private void Start()
        {
            miniGame = new HydrationPlageTaper();
            MiniGameManager.Instance.StartMiniGame(miniGame, this);
        }
        
        public HydrationPlageTaperContext GetContext()
        {
            return new HydrationPlageTaperContext
            {
                miniGameData = miniGameData,
                isFinished = buvoir.isFinished
            };
        }
    }
}