using NomDuJeu.MiniGames.Core.Core.MiniGames.Core;
using NomDuJeu.MiniGames.Core.Core.MiniGames.Core.Interfaces;
using UnityEngine;

namespace NomDuJeu.Core.MiniGames.Sample.SortAndSplode
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