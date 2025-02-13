
using CIRC.MiniGames.Core;
using CIRC.MiniGames.Core.Interfaces;
using CIRC.Progression;
using UnityEngine;

namespace CIRC.MiniGames.Sample
{
    public class HydratationPlageTournerHandler : MonoBehaviour, IMiniGameHandler<HydratationPlageTournerContext>
    {
        [SerializeField] private MiniGameDataHolder miniGameData;
        [SerializeField] private Levier levier;
        
        private HydratationPlageTourner miniGame;
        
        
        private void Start()
        {
            miniGame = new HydratationPlageTourner();
            MiniGameManager.Instance.StartMiniGame(miniGame, this);
        }
        
        public HydratationPlageTournerContext GetContext()
        {
            return new HydratationPlageTournerContext
            {
                miniGameData = miniGameData,
                isFinished = levier.isFinished
            };
        }
    }
}