using NomDuJeu.MiniGames.Core.Core.MiniGames.Core.Interfaces;

namespace NomDuJeu.MiniGames.Core
{
    public abstract class MiniGame<T> : IMiniGame 
        where T : IMiniGameContext
    {
        public abstract void Begin(ref T context);
        
        public abstract bool Refresh(ref T context);
        
        public abstract void End(ref T context, bool isSuccess);
    }
}