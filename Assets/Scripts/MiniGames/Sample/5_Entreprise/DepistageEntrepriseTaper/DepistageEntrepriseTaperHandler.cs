
using CIRC.MiniGames.Core;
using CIRC.MiniGames.Core.Interfaces;
using CIRC.Progression;
using UnityEngine;

namespace CIRC.MiniGames.Sample
{
    public class DepistageEntrepriseTaperHandler : MonoBehaviour, IMiniGameHandler<DepistageEntrepriseTaperContext>
    {
        [SerializeField] private MiniGameDataHolder miniGameData;
        [SerializeField] private Doors doors;
        
        private DepistageEntrepriseTaper miniGame;
        
        private void Start()
        {
            miniGame = new DepistageEntrepriseTaper();
            MiniGameManager.Instance.StartMiniGame(miniGame, this);
        }
        
        public DepistageEntrepriseTaperContext GetContext()
        {
            return new DepistageEntrepriseTaperContext
            {
                miniGameData = miniGameData,
                isRight = doors.isRight,
            };
        }
    }
}