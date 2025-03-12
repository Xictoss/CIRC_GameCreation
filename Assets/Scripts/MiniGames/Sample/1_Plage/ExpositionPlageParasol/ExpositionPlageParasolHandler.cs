
using CIRC.MiniGames.Core;
using CIRC.MiniGames.Core.Interfaces;
using CIRC.Progression;
using UnityEngine;

namespace CIRC.MiniGames.Sample
{
    public class ExpositionPlageParasolHandler : MonoBehaviour, IMiniGameHandler<ExpositionPlageParasolContext>
    {
        [SerializeField] private MiniGameDataHolder miniGameData;
        [SerializeField] private Parasol parasol;
        
        private ExpositionPlageParasol miniGame;
        
        private void Start()
        {
            miniGame = new ExpositionPlageParasol();
            MiniGameManager.Instance.StartMiniGame(miniGame, this);
        }
        
        public ExpositionPlageParasolContext GetContext()
        {
            return new ExpositionPlageParasolContext
            {
                miniGameData = miniGameData,
                isFinished = parasol.isFinished
            };
        }
    }
}