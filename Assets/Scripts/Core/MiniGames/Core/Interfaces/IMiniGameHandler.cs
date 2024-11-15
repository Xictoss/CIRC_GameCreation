namespace NomDuJeu.MiniGames.Core.Core.MiniGames.Core.Interfaces
{
    public interface IMiniGameHandler<T> where T : IMiniGameContext
    {
        T GetContext();
    }
}