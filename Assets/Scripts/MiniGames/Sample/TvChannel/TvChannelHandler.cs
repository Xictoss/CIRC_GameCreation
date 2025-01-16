using CIRC.MiniGames.Core;
using CIRC.MiniGames.Core.Interfaces;
using CIRC.Progression;
using UnityEngine;

namespace CIRC.MiniGames.Sample
{
    public class TvChannelHandler : MonoBehaviour, IMiniGameHandler<TvChannelContext>
    {
        [SerializeField] private MiniGameDataHolder miniGameData;
        
        private TvChannel miniGame;
        
        private void Start()
        {
            miniGame = new TvChannel();
            MiniGameManager.Instance.StartMiniGame(miniGame, this);
        }
        
        public TvChannelContext GetContext()
        {
            return new TvChannelContext
            {
                MiniGameData = miniGameData,
            };
        }

        public void Initialize(MiniGameDataHolder miniGameData)
        {
            this.miniGameData = miniGameData;
        }
    }
}