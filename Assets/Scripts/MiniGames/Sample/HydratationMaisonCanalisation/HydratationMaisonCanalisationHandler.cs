using CIRC.MiniGames.Core;
using CIRC.MiniGames.Core.Interfaces;
using CIRC.Progression;
using UnityEngine;

namespace CIRC.MiniGames.Sample
{
    public class HydratationMaisonCanalisationHandler : MonoBehaviour, IMiniGameHandler<HydratationMaisonCanalisationContext>
    {
        [SerializeField] private MiniGameDataHolder miniGameData;
        [SerializeField] private RotatingPiece[] pipes;
        
        private HydratationMaisonCanalisation hydratationMaisonCanalisation;
        
        private void Start()
        {
            hydratationMaisonCanalisation = new HydratationMaisonCanalisation();
            MiniGameManager.Instance.StartMiniGame(hydratationMaisonCanalisation, this);
        }
        
        public HydratationMaisonCanalisationContext GetContext()
        {
            return new HydratationMaisonCanalisationContext
            {
                MiniGameData = miniGameData,
                pipes = pipes,
            };
        }
    }
}