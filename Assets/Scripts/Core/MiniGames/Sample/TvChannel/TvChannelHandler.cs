using CIRC.Core.MiniGames.Core;
using CIRC.Core.MiniGames.Core.Interfaces;
using CIRC.Core.Progression.Core.Data;
using UnityEngine;
using UnityEngine.Serialization;

namespace CIRC.Core.MiniGames.Sample.TvChannel
{
    public class TvChannelHandler : MonoBehaviour, IMiniGameHandler<TvChannelContext>
    {
        [FormerlySerializedAs("miniGameData")] [SerializeField] private MiniGameDataOLD miniGameDataOld;
        
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
                MiniGameDataOld = miniGameDataOld,
            };
        }

        public void Initialize(MiniGameDataOLD miniGameDataOld)
        {
            this.miniGameDataOld = miniGameDataOld;
        }
    }
}