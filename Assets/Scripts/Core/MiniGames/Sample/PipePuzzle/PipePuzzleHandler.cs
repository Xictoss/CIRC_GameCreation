using CIRC.Core.MiniGames.Core;
using CIRC.Core.MiniGames.Core.Interfaces;
using CIRC.Core.Progression.Core.Data;
using UnityEngine;
using UnityEngine.Serialization;

namespace CIRC.Core.MiniGames.Sample.Core.MiniGames.Sample.PipePuzzle
{
    public class PipePuzzleHandler : MonoBehaviour, IMiniGameHandler<PipePuzzleContext>
    {
        [FormerlySerializedAs("miniGameData")] [SerializeField] private MiniGameDataOLD miniGameDataOld;
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
                MiniGameDataOld = miniGameDataOld,
                pipes = pipes,
            };
        }
    }
}