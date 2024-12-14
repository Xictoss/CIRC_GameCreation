using CIRC.Core.MiniGames.Core;
using CIRC.Core.MiniGames.Core.Interfaces;
using CIRC.Core.Progression.Core.Data;
using UnityEngine;
using UnityEngine.Serialization;

namespace CIRC.Core.MiniGames.Sample.AlcoolMaisonFrigo
{
    public class AlcoolMaisonFrigoHandler : MonoBehaviour, IMiniGameHandler<AlcoolMaisonFrigoContext>
    {
        [FormerlySerializedAs("miniGameData")] [SerializeField] private MiniGameDataOLD miniGameDataOld;
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
                MiniGameDataOld = miniGameDataOld,
                alcoolMaisonFrigoChoose = alcoolMaisonFrigoChoose
            };
        }
    }
}