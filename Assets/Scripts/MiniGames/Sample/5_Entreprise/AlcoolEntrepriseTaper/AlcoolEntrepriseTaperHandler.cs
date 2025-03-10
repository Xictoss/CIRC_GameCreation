
using CIRC.MiniGames.Core;
using CIRC.MiniGames.Core.Interfaces;
using CIRC.Progression;
using UnityEngine;

namespace CIRC.MiniGames.Sample
{
    public class AlcoolEntrepriseTaperHandler : MonoBehaviour, IMiniGameHandler<AlcoolEntrepriseTaperContext>
    {
        [SerializeField] private MiniGameDataHolder miniGameData;
        [SerializeField] private Fountains fountains;
        
        private AlcoolEntrepriseTaper miniGame;
        
        private void Start()
        {
            miniGame = new AlcoolEntrepriseTaper();
            MiniGameManager.Instance.StartMiniGame(miniGame, this);
        }
        
        public AlcoolEntrepriseTaperContext GetContext()
        {
            return new AlcoolEntrepriseTaperContext
            {
                miniGameData = miniGameData,
                isRight = fountains.isRight
            };
        }
    }
}