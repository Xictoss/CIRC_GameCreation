
using CIRC.MiniGames.Core;
using CIRC.MiniGames.Core.Interfaces;
using CIRC.Progression;
using UnityEngine;

namespace CIRC.MiniGames.Sample
{
    public class TabagismePlageCigaretteHandler : MonoBehaviour, IMiniGameHandler<TabagismePlageCigaretteContext>
    {
        [SerializeField] private MiniGameDataHolder miniGameData;
        [SerializeField] private Cigarette _cigarette;
        
        private TabagismePlageCigarette miniGame;
        
        private void Start()
        {
            miniGame = new TabagismePlageCigarette();
            MiniGameManager.Instance.StartMiniGame(miniGame, this);
        }
        
        public TabagismePlageCigaretteContext GetContext()
        {
            return new TabagismePlageCigaretteContext
            {
                miniGameData = miniGameData,
                isDone = _cigarette.isDone
            };
        }
    }
}