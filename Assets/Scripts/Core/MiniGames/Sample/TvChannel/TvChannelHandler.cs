using CIRC.Core.MiniGames.Core;
using CIRC.Core.MiniGames.Core.Interfaces;
using CIRC.Core.Scriptables.Core;
using UnityEngine;

namespace CIRC.Core.MiniGames.Sample.TvChannel
{
    public class TvChannelHandler : MonoBehaviour, IMiniGameHandler<TvChannelContext>
    {
        [SerializeField] private MiniGameData miniGameData;
        
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
                miniGameData = miniGameData,
            };
        }
    }
}