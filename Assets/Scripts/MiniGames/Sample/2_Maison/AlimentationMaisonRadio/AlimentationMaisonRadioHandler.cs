
using CIRC.MiniGames.Core;
using CIRC.MiniGames.Core.Interfaces;
using CIRC.Progression;
using UnityEngine;

namespace CIRC.MiniGames.Sample
{
    public class AlimentationMaisonRadioHandler : MonoBehaviour, IMiniGameHandler<AlimentationMaisonRadioContext>
    {
        [SerializeField] private MiniGameDataHolder miniGameData;
        [SerializeField] private RadioController radioController;
        
        private AlimentationMaisonRadio miniGame;
        
        private void Start()
        {
            miniGame = new AlimentationMaisonRadio();
            MiniGameManager.Instance.StartMiniGame(miniGame, this);
        }
        
        public AlimentationMaisonRadioContext GetContext()
        {
            return new AlimentationMaisonRadioContext
            {
                miniGameData = miniGameData,
                isArrived = radioController.IsArrived,
            };
        }
    }
}