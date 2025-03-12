
using CIRC.MiniGames.Core;
using CIRC.MiniGames.Core.Interfaces;
using CIRC.Progression;
using UnityEngine;

namespace CIRC.MiniGames.Sample
{
    public class ActiviteLotissementTaperHandler : MonoBehaviour, IMiniGameHandler<ActiviteLotissementTaperContext>
    {
        [SerializeField] private MiniGameDataHolder miniGameData;
        [SerializeField] private GuyToMotivate guyToMotivate;
        
        private ActiviteLotissementTaper miniGame;
        
        private void Start()
        {
            miniGame = new ActiviteLotissementTaper();
            MiniGameManager.Instance.StartMiniGame(miniGame, this);
        }
        
        public ActiviteLotissementTaperContext GetContext()
        {
            return new ActiviteLotissementTaperContext
            {
                miniGameData = miniGameData,
                isArrived = guyToMotivate.isArrived
            };
        }
    }
}