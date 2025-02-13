using CIRC.MiniGames.Core;
using CIRC.MiniGames.Core.Interfaces;
using CIRC.Progression;
using UnityEngine;

namespace CIRC.MiniGames.Sample
{
    public class HormoneMaisonJeterHandler : MonoBehaviour, IMiniGameHandler<HormoneMaisonJeterContext>
    {
        [SerializeField] private MiniGameDataHolder miniGameData;
        [SerializeField] private PillsManager pillsManager;
        
        private HormoneMaisonJeter miniGame;
        
        private void Start()
        {
            miniGame = new HormoneMaisonJeter();
            MiniGameManager.Instance.StartMiniGame(miniGame, this);
        }
        
        public HormoneMaisonJeterContext GetContext()
        {
            return new HormoneMaisonJeterContext
            {
                miniGameData = miniGameData,
                pillsManager = pillsManager,
            };
        }
    }
}