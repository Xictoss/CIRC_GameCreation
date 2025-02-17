
using CIRC.MiniGames.Core;
using CIRC.MiniGames.Core.Interfaces;
using CIRC.Progression;
using UnityEngine;

namespace CIRC.MiniGames.Sample
{
    public class AlcoolLotissementTaperHandler : MonoBehaviour, IMiniGameHandler<AlcoolLotissementTaperContext>
    {
        [SerializeField] private MiniGameDataHolder miniGameData;
        [SerializeField] private ChoiceManager choiceManager;
        
        private AlcoolLotissementTaper miniGame;
        
        private void Start()
        {
            miniGame = new AlcoolLotissementTaper();
            MiniGameManager.Instance.StartMiniGame(miniGame, this);
        }
        
        public AlcoolLotissementTaperContext GetContext()
        {
            return new AlcoolLotissementTaperContext
            {
                miniGameData = miniGameData,
                isChooseGreat = choiceManager.Finished
            };
        }
    }
}