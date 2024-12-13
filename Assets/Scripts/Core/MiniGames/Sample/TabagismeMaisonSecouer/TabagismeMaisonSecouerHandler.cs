using CIRC.Core.MiniGames.Core;
using CIRC.Core.MiniGames.Core.Interfaces;
using CIRC.Core.Progression.Core.Data;
using UnityEngine;

namespace CIRC.Core.MiniGames.Sample.TabagismeMaisonSecouer
{
    public class TabagismeMaisonSecouerHandler : MonoBehaviour, IMiniGameHandler<TabagismeMaisonSecouerContext>
    {
        [SerializeField] private MiniGameData miniGameData;
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
                miniGameData = miniGameData,
                smokes = smokes,
            };
        }
    }
}