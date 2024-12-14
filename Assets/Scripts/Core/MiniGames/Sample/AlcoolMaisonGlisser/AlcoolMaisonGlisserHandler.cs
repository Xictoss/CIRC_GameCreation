using CIRC.Core.MiniGames.Core;
using CIRC.Core.MiniGames.Core.Interfaces;
using CIRC.Core.Progression.Core.Data;
using UnityEngine;
using UnityEngine.Serialization;

namespace CIRC.Core.MiniGames.Sample.AlcoolMaisonGlisser
{
    public class AlcoolMaisonGlisserHandler : MonoBehaviour, IMiniGameHandler<AlcoolMaisonGlisserContext>
    {
        [FormerlySerializedAs("miniGameData")] [SerializeField] private MiniGameDataOLD miniGameDataOld;
        
        private AlcoolMaisonGlisser miniGame;
        
        private void Start()
        {
            miniGame = new AlcoolMaisonGlisser();
            MiniGameManager.Instance.StartMiniGame(miniGame, this);
        }
        
        public AlcoolMaisonGlisserContext GetContext()
        {
            return new AlcoolMaisonGlisserContext
            {
                MiniGameDataOld = miniGameDataOld,
            };
        }
    }
}