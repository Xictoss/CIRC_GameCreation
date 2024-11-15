using CIRC.Core.MiniGames.Core.Interfaces;

namespace CIRC.Core.MiniGames.Core
{
    public sealed class MiniGameRunner<T> : IMiniGameRunner 
        where T : IMiniGameContext
    {
        public IMiniGame MiniGame => miniGame;

        private readonly MiniGame<T> miniGame;
        private readonly IMiniGameHandler<T> handler;

        public MiniGameRunner(MiniGame<T> miniGame, IMiniGameHandler<T> handler)
        {
            this.miniGame = miniGame;
            this.handler = handler;
        }

        public void Begin()
        {
            T context = handler.GetContext();
            miniGame.Begin(ref context);
        }
        
        public bool Refresh()
        {
            T context = handler.GetContext();
            return miniGame.Refresh(ref context);
        }
        
        public void End(bool isSuccess)
        {
            T context = handler.GetContext();
            miniGame.End(ref context, isSuccess);
        }
    }
}