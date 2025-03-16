
using CIRC.MiniGames.Core;
using CIRC.MiniGames.Core.Interfaces;
using CIRC.Progression;
using UnityEngine;

namespace CIRC.MiniGames.Sample
{
    public class AlimentationVilleGlisserHandler : MonoBehaviour, IMiniGameHandler<AlimentationVilleGlisserContext>
    {
        [SerializeField] private MiniGameDataHolder miniGameData;
        [SerializeField] private Key key;
        
        private AlimentationVilleGlisser miniGame;
        
        private void Start()
        {
            miniGame = new AlimentationVilleGlisser();
            MiniGameManager.Instance.StartMiniGame(miniGame, this);
        }
        
        public AlimentationVilleGlisserContext GetContext()
        {
            return new AlimentationVilleGlisserContext
            {
                miniGameData = miniGameData,
                isPlaced = key.IsPlaced
            };
        }
    }
}