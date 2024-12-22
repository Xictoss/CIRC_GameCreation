using CIRC.Core.MiniGames.Core;
using CIRC.Core.MiniGames.Core.Interfaces;
using CIRC.Core.Progression.Core;
using UnityEngine;

namespace CIRC.Core.MiniGames.Sample.AlcoolMaisonGlisser
{
    public class AlcoolMaisonGlisserHandler : MonoBehaviour, IMiniGameHandler<AlcoolMaisonGlisserContext>
    {
        [SerializeField] private MiniGameData miniGameData;
        
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