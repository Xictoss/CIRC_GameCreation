
using CIRC.MiniGames.Core;
using CIRC.MiniGames.Core.Interfaces;
using CIRC.Progression;
using UnityEngine;

namespace CIRC.MiniGames.Sample
{
    public class VaccinationEntrepriseDragHandler : MonoBehaviour, IMiniGameHandler<VaccinationEntrepriseDragContext>
    {
        [SerializeField] private MiniGameDataHolder miniGameData;
        [SerializeField] private Pensement pensement;
        
        private VaccinationEntrepriseDrag miniGame;
        
        private void Start()
        {
            miniGame = new VaccinationEntrepriseDrag();
            MiniGameManager.Instance.StartMiniGame(miniGame, this);
        }
        
        public VaccinationEntrepriseDragContext GetContext()
        {
            return new VaccinationEntrepriseDragContext
            {
                miniGameData = miniGameData,
                pensement = pensement,
            };
        }
    }
}