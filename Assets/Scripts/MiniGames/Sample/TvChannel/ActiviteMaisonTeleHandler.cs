using CIRC.MiniGames.Core;
using CIRC.MiniGames.Core.Interfaces;
using CIRC.Progression;
using UnityEngine;

namespace CIRC.MiniGames.Sample
{
    public class ActiviteMaisonTeleHandler : MonoBehaviour, IMiniGameHandler<ActiviteMaisonTeleContext>
    {
        [SerializeField] private MiniGameDataHolder miniGameData;
        [SerializeField] private TV tv;
        
        private ActiviteMaisonTele miniGame;
        
        private void Start()
        {
            miniGame = new ActiviteMaisonTele();
            MiniGameManager.Instance.StartMiniGame(miniGame, this);
        }
        
        public ActiviteMaisonTeleContext GetContext()
        {
            return new ActiviteMaisonTeleContext
            {
                MiniGameData = miniGameData,
                IsArrived = tv.IsArrived,
            };
        }
    }
}