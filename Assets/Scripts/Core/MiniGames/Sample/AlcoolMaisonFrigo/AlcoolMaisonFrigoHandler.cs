using CIRC.Core.MiniGames.Core;
using CIRC.Core.MiniGames.Core.Interfaces;
using CIRC.Core.Progression.Core.Data;
using UnityEngine;

namespace CIRC.Core.MiniGames.Sample.AlcoolMaisonFrigo
{
    public class AlcoolMaisonFrigoHandler : MonoBehaviour, IMiniGameHandler<AlcoolMaisonFrigoContext>
    {
        [SerializeField] private MiniGameData miniGameData;
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
                miniGameData = miniGameData,
                alcoolMaisonFrigoChoose = alcoolMaisonFrigoChoose
            };
        }
    }
}