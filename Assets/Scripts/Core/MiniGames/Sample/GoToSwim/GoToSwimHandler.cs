using CIRC.Core.MiniGames.Core;
using CIRC.Core.MiniGames.Core.Interfaces;
using CIRC.Core.Progression.Core.Data;
using UnityEngine;
using UnityEngine.Serialization;


namespace CIRC.Core.MiniGames.Sample.GoToSwim
{
    public class GoToSwimHandler : MonoBehaviour, IMiniGameHandler<GoToSwimContext>
    {
        [FormerlySerializedAs("_miniGameData")] [SerializeField] private MiniGameDataOLD miniGameDataOld;
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
                MiniGameDataOld = miniGameDataOld,
                isArrived = _guyRun.IsArrived,
            };
        }
    }
}