using CIRC.MiniGames.Core;
using CIRC.MiniGames.Core.Interfaces;
using CIRC.Progression;
using UnityEngine;

namespace CIRC.MiniGames.Sample
{
    public class ActivitePlageNagerHandler : MonoBehaviour, IMiniGameHandler<ActivitePlageNagerContext>
    {
        [SerializeField] private MiniGameDataHolder miniGameDataOld;
        [SerializeField] private GuyRun _guyRun;
        
        private ActivitePlageNager miniGame;
        private void Start()
        {
            miniGame = new ActivitePlageNager();
            MiniGameManager.Instance.StartMiniGame(miniGame, this);
        }
        
        public ActivitePlageNagerContext GetContext()
        {
            return new ActivitePlageNagerContext
            {
                MiniGameData = miniGameDataOld,
                isArrived = _guyRun.IsArrived,
            };
        }
    }
}