namespace CIRC.Core.MiniGames.Core.Interfaces
{
    public interface IMiniGameHandler<T> where T : IMiniGameContext
    {
        T GetContext();
    }
}