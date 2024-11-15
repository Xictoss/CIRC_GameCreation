using CIRC.Core.MiniGames.Core;
using CIRC.Core.MiniGames.Core.Interfaces;
using UnityEngine;

namespace CIRC.Core.MiniGames.Sample.SortAndSplodeMiniGame
{
    public class SortAndSplodeHandler : MonoBehaviour, IMiniGameHandler<SortAndSplodeContext>
    {
        [SerializeField] private string miniGameName;

        private SortAndSplode miniGame;

        private void Start()
        {
            miniGame = new SortAndSplode();
            MiniGameManager.Instance.StartMiniGame(miniGame, this);
        }
        
        public SortAndSplodeContext GetContext()
        {
            return new SortAndSplodeContext
            {
                Name = miniGameName
            };
        }
    }
}