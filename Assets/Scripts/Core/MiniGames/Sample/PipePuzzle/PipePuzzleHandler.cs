using CIRC.Core.MiniGames.Core;
using CIRC.Core.MiniGames.Core.Interfaces;
using CIRC.Core.Progression.Core;
using UnityEngine;

namespace CIRC.Core.MiniGames.Sample.Core.MiniGames.Sample.PipePuzzle
{
    public class PipePuzzleHandler : MonoBehaviour, IMiniGameHandler<PipePuzzleContext>
    {
        [SerializeField] private MiniGameDataHolder miniGameData;
        [SerializeField] private RotatingPiece[] pipes;
        
        private PipePuzzle pipePuzzle;
        
        private void Start()
        {
            pipePuzzle = new PipePuzzle();
            MiniGameManager.Instance.StartMiniGame(pipePuzzle, this);
        }
        
        public PipePuzzleContext GetContext()
        {
            return new PipePuzzleContext
            {
                MiniGameData = miniGameData,
                pipes = pipes,
            };
        }
    }
}