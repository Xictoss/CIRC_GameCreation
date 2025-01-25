
using CIRC.MiniGames.Core;
using CIRC.MiniGames.Core.Interfaces;
using CIRC.Progression;
using UnityEngine;

namespace CIRC.MiniGames.Sample
{
    public class ActiviteEntrepriseDragHandler : MonoBehaviour, IMiniGameHandler<ActiviteEntrepriseDragContext>
    {
        [SerializeField] private MiniGameDataHolder miniGameData;
        [SerializeField] private Poster[] posters;
        
        private ActiviteEntrepriseDrag miniGame;
        
        private void Start()
        {
            miniGame = new ActiviteEntrepriseDrag();
            MiniGameManager.Instance.StartMiniGame(miniGame, this);
        }
        
        public ActiviteEntrepriseDragContext GetContext()
        {
            return new ActiviteEntrepriseDragContext
            {
                miniGameData = miniGameData,
                posters = posters,
            };
        }
    }
}