
using CIRC.MiniGames.Core;
using CIRC.MiniGames.Core.Interfaces;
using CIRC.Progression;
using UnityEngine;
using UnityEngine.Serialization;

namespace CIRC.MiniGames.Sample
{
    public class AlimentationEntrepriseTaperHandler : MonoBehaviour, IMiniGameHandler<AlimentationEntrepriseTaperContext>
    {
        [SerializeField] private MiniGameDataHolder miniGameData;
        [FormerlySerializedAs("goodEntity")] [SerializeField] private Entitys entitys;
        
        private AlimentationEntrepriseTaper miniGame;
        
        private void Start()
        {
            miniGame = new AlimentationEntrepriseTaper();
            MiniGameManager.Instance.StartMiniGame(miniGame, this);
        }
        
        public AlimentationEntrepriseTaperContext GetContext()
        {
            return new AlimentationEntrepriseTaperContext
            {
                miniGameData = miniGameData,
                isRight = entitys.isRight
            };
        }
    }
}