namespace CIRC.MiniGames.Core.Interfaces
{
    public interface IMiniGameHandler<T> where T : IMiniGameContext
    {
        T GetContext();
    }
}