using CIRC.Core.MiniGames.Core;
using CIRC.Core.MiniGames.Core.Interfaces;
using CIRC.Core.Progression.Core;
using UnityEngine;

namespace CIRC.Core.MiniGames.Sample.TvChannel
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