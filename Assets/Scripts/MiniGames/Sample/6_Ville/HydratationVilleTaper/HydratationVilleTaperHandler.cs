
using CIRC.MiniGames.Core;
using CIRC.MiniGames.Core.Interfaces;
using CIRC.Progression;
using UnityEngine;
using UnityEngine.Serialization;

namespace CIRC.MiniGames.Sample
{
    public class HydratationVilleTaperHandler : MonoBehaviour, IMiniGameHandler<HydratationVilleTaperContext>
    {
        [SerializeField] private MiniGameDataHolder miniGameData;
        [SerializeField] private Bottle bottle;
        
        private HydratationVilleTaper miniGame;
        
        private void Start()
        {
            miniGame = new HydratationVilleTaper();
            MiniGameManager.Instance.StartMiniGame(miniGame, this);
        }
        
        public HydratationVilleTaperContext GetContext()
        {
            return new HydratationVilleTaperContext
            {
                miniGameData = miniGameData,
                isRight = bottle.isRight
            };
        }
    }
}