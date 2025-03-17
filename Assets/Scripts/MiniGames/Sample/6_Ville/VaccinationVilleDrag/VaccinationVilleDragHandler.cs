
using CIRC.MiniGames.Core;
using CIRC.MiniGames.Core.Interfaces;
using CIRC.Progression;
using UnityEngine;

namespace CIRC.MiniGames.Sample
{
    public class VaccinationVilleDragHandler : MonoBehaviour, IMiniGameHandler<VaccinationVilleDragContext>
    {
        [SerializeField] private MiniGameDataHolder miniGameData;
        [SerializeField] private VactinationBandage vactinationBandage;
        
        private VaccinationVilleDrag miniGame;
        
        private void Start()
        {
            miniGame = new VaccinationVilleDrag();
            MiniGameManager.Instance.StartMiniGame(miniGame, this);
        }
        
        public VaccinationVilleDragContext GetContext()
        {
            return new VaccinationVilleDragContext
            {
                miniGameData = miniGameData,
                IsPlaced = vactinationBandage.IsPlaced
            };
        }
    }
}