
using System;
using CIRC.MiniGames.Core;
using CIRC.MiniGames.Core.Interfaces;
using CIRC.Progression;
using UnityEngine;

namespace CIRC.MiniGames.Sample
{
    public class ActiviteLotissementDragHandler : MonoBehaviour, IMiniGameHandler<ActiviteLotissementDragContext>
    {
        [SerializeField] private MiniGameDataHolder miniGameData;
        [SerializeField] private FootBall footBall;
        
        private ActiviteLotissementDrag miniGame;

        private void Start()
        {
            miniGame = new ActiviteLotissementDrag();
            MiniGameManager.Instance.StartMiniGame(miniGame, this);
        }
        
        public ActiviteLotissementDragContext GetContext()
        {
            return new ActiviteLotissementDragContext
            {
                miniGameData = miniGameData,
                isFinished = footBall.isFinished
            };
        }
    }
}