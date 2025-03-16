
using CIRC.MiniGames.Core;
using CIRC.MiniGames.Core.Interfaces;
using CIRC.Progression;
using UnityEngine;

namespace CIRC.MiniGames.Sample
{
    public class ProgrammesVilleTaperHandler : MonoBehaviour, IMiniGameHandler<ProgrammesVilleTaperContext>
    {
        [SerializeField] private MiniGameDataHolder miniGameData;
        [SerializeField] private Papillon _papillon;
        
        private ProgrammesVilleTaper miniGame;
        
        private void Start()
        {
            miniGame = new ProgrammesVilleTaper();
            MiniGameManager.Instance.StartMiniGame(miniGame, this);
        }
        
        public ProgrammesVilleTaperContext GetContext()
        {
            return new ProgrammesVilleTaperContext
            {
                miniGameData = miniGameData,
                isPlaced = _papillon.IsPlaced
            };
        }
    }
}