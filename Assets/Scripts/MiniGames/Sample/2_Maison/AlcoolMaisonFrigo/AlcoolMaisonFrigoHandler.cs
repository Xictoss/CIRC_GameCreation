using CIRC.MiniGames.Core;
using CIRC.MiniGames.Core.Interfaces;
using CIRC.Progression;
using UnityEngine;

namespace CIRC.MiniGames.Sample
{
    public class AlcoolMaisonFrigoHandler : MonoBehaviour, IMiniGameHandler<AlcoolMaisonFrigoContext>
    {
        [SerializeField] private MiniGameDataHolder miniGameData;
        [SerializeField] private AlcoolMaisonFrigoChoose alcoolMaisonFrigoChoose;
        
        private AlcoolMaisonFrigo miniGame;
        
        private void Start()
        {
            miniGame = new AlcoolMaisonFrigo();
            MiniGameManager.Instance.StartMiniGame(miniGame, this);
        }
        
        public AlcoolMaisonFrigoContext GetContext()
        {
            return new AlcoolMaisonFrigoContext
            {
                MiniGameData = miniGameData,
                alcoolMaisonFrigoChoose = alcoolMaisonFrigoChoose
            };
        }
    }
}