
using CIRC.MiniGames.Core;
using CIRC.MiniGames.Core.Interfaces;
using CIRC.Progression;
using UnityEngine;

namespace CIRC.MiniGames.Sample
{
    public class ActiviteVilleTaperHandler : MonoBehaviour, IMiniGameHandler<ActiviteVilleTaperContext>
    {
        [SerializeField] private MiniGameDataHolder miniGameData;
        [SerializeField] private Bike bike;
        
        private ActiviteVilleTaper miniGame;
        
        private void Start()
        {
            miniGame = new ActiviteVilleTaper();
            MiniGameManager.Instance.StartMiniGame(miniGame, this);
        }
        
        public ActiviteVilleTaperContext GetContext()
        {
            return new ActiviteVilleTaperContext
            {
                miniGameData = miniGameData,
                isArrived = bike.IsArrived
            };
        }
    }
}