using CIRC.MiniGames.Core;
using CIRC.MiniGames.Core.Interfaces;
using CIRC.Progression;
using UnityEngine;

namespace CIRC.MiniGames.Sample
{
    public class TabagismeMaisonSecouerHandler : MonoBehaviour, IMiniGameHandler<TabagismeMaisonSecouerContext>
    {
        [SerializeField] private MiniGameDataHolder miniGameData;
        [SerializeField] private Smoke[] smokes;
        
        private TabagismeMaisonSecouer miniGame;
        
        private void Start()
        {
            miniGame = new TabagismeMaisonSecouer();
            MiniGameManager.Instance.StartMiniGame(miniGame, this);
        }
        
        public TabagismeMaisonSecouerContext GetContext()
        {
            return new TabagismeMaisonSecouerContext
            {
                MiniGameData = miniGameData,
                smokes = smokes,
            };
        }
    }
}