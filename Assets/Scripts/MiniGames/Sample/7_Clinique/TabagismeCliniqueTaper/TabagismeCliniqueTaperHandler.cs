
using CIRC.MiniGames.Core;
using CIRC.MiniGames.Core.Interfaces;
using CIRC.Progression;
using UnityEngine;

namespace CIRC.MiniGames.Sample
{
    public class TabagismeCliniqueTaperHandler : MonoBehaviour, IMiniGameHandler<TabagismeCliniqueTaperContext>
    {
        [SerializeField] private MiniGameDataHolder miniGameData;
        [SerializeField] private Cancer _cancer;
        
        private TabagismeCliniqueTaper miniGame;
        
        private void Start()
        {
            miniGame = new TabagismeCliniqueTaper();
            MiniGameManager.Instance.StartMiniGame(miniGame, this);
        }
        
        public TabagismeCliniqueTaperContext GetContext()
        {
            return new TabagismeCliniqueTaperContext
            {
                miniGameData = miniGameData,
                isRight = _cancer.isRight,
            };
        }
    }
}