
using CIRC.MiniGames.Core;
using CIRC.MiniGames.Core.Interfaces;
using CIRC.Progression;
using UnityEngine;

namespace CIRC.MiniGames.Sample
{
    public class AlcoolMaisonBoissonHandler : MonoBehaviour, IMiniGameHandler<AlcoolMaisonBoissonContext>
    {
        [SerializeField] private MiniGameDataHolder miniGameData;
        [SerializeField] private Glass glass;
        
        private AlcoolMaisonBoisson miniGame;
        
        private void Start()
        {
            miniGame = new AlcoolMaisonBoisson();
            MiniGameManager.Instance.StartMiniGame(miniGame, this);
        }
        
        public AlcoolMaisonBoissonContext GetContext()
        {
            return new AlcoolMaisonBoissonContext
            {
                miniGameData = miniGameData,
                glass = glass,
            };
        }
    }
}