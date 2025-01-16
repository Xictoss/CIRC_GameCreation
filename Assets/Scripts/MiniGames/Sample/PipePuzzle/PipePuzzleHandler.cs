using CIRC.MiniGames.Core;
using CIRC.MiniGames.Core.Interfaces;
using CIRC.Progression;
using UnityEngine;

namespace CIRC.MiniGames.Sample
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