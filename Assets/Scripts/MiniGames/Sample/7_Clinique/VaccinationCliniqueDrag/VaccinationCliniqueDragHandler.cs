
using CIRC.MiniGames.Core;
using CIRC.MiniGames.Core.Interfaces;
using CIRC.Progression;
using UnityEngine;

namespace CIRC.MiniGames.Sample
{
    public class VaccinationCliniqueDragHandler : MonoBehaviour, IMiniGameHandler<VaccinationCliniqueDragContext>
    {
        [SerializeField] private MiniGameDataHolder miniGameData;
        [SerializeField] private Bandage2 bandage2;
        
        private VaccinationCliniqueDrag miniGame;
        
        private void Start()
        {
            miniGame = new VaccinationCliniqueDrag();
            MiniGameManager.Instance.StartMiniGame(miniGame, this);
        }
        
        public VaccinationCliniqueDragContext GetContext()
        {
            return new VaccinationCliniqueDragContext
            {
                miniGameData = miniGameData,
                IsPlaced = bandage2.IsPlaced
            };
        }
    }
}