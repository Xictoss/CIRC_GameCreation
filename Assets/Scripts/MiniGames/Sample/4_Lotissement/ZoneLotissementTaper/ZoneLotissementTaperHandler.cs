
using CIRC.MiniGames.Core;
using CIRC.MiniGames.Core.Interfaces;
using CIRC.Progression;
using UnityEngine;

namespace CIRC.MiniGames.Sample
{
    public class ZoneLotissementTaperHandler : MonoBehaviour, IMiniGameHandler<ZoneLotissementTaperContext>
    {
        [SerializeField] private MiniGameDataHolder miniGameData;
        [SerializeField] private MoleculeManager moleculeManager;
        
        private ZoneLotissementTaper miniGame;
        
        private void Start()
        {
            miniGame = new ZoneLotissementTaper();
            MiniGameManager.Instance.StartMiniGame(miniGame, this);
        }
        
        public ZoneLotissementTaperContext GetContext()
        {
            return new ZoneLotissementTaperContext
            {
                miniGameData = miniGameData,
                Finished = moleculeManager.IsFinished
            };
        }
    }
}