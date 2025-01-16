using CIRC.MiniGames.Core;
using CIRC.MiniGames.Core.Interfaces;
using CIRC.Progression;
using UnityEngine;

namespace CIRC.MiniGames.Sample
{
    public class GoToSwimHandler : MonoBehaviour, IMiniGameHandler<GoToSwimContext>
    {
        [SerializeField] private MiniGameDataHolder miniGameDataOld;
        [SerializeField] private GuyRun _guyRun;
        
        private GoToSwim miniGame;
        private void Start()
        {
            miniGame = new GoToSwim();
            MiniGameManager.Instance.StartMiniGame(miniGame, this);
        }
        
        public GoToSwimContext GetContext()
        {
            return new GoToSwimContext
            {
                MiniGameData = miniGameDataOld,
                isArrived = _guyRun.IsArrived,
            };
        }
    }
}