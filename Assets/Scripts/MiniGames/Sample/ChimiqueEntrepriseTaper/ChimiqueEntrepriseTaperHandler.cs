
using CIRC.MiniGames.Core;
using CIRC.MiniGames.Core.Interfaces;
using CIRC.Progression;
using UnityEngine;

namespace CIRC.MiniGames.Sample
{
    public class ChimiqueEntrepriseTaperHandler : MonoBehaviour, IMiniGameHandler<ChimiqueEntrepriseTaperContext>
    {
        [SerializeField] private MiniGameDataHolder miniGameData;
        [SerializeField] private Hole[] holes;
        
        private ChimiqueEntrepriseTaper miniGame;
        
        private void Start()
        {
            miniGame = new ChimiqueEntrepriseTaper();
            MiniGameManager.Instance.StartMiniGame(miniGame, this);
        }
        
        public ChimiqueEntrepriseTaperContext GetContext()
        {
            return new ChimiqueEntrepriseTaperContext
            {
                miniGameData = miniGameData,
                holes = holes,
            };
        }
    }
}