using CIRC.MiniGames.Core;
using CIRC.MiniGames.Core.Interfaces;
using CIRC.Progression;
using UnityEngine;

namespace CIRC.MiniGames.Sample
{
    public class AlcoolMaisonGlisserHandler : MonoBehaviour, IMiniGameHandler<AlcoolMaisonGlisserContext>
    {
        [SerializeField] private MiniGameDataHolder miniGameData;
        
        private AlcoolMaisonGlisser miniGame;
        
        private void Start()
        {
            miniGame = new AlcoolMaisonGlisser();
            MiniGameManager.Instance.StartMiniGame(miniGame, this);
        }
        
        public AlcoolMaisonGlisserContext GetContext()
        {
            return new AlcoolMaisonGlisserContext
            {
                MiniGameData = miniGameData,
            };
        }
    }
}