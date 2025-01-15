using CIRC.Core.MiniGames.Core;
using CIRC.Core.MiniGames.Core.Interfaces;
using CIRC.Core.Progression.Core;
using UnityEngine;

namespace CIRC.Core.MiniGames.Sample.GoToSwim
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