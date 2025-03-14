namespace CIRC.MiniGames.Core.Interfaces
{
    public interface IMiniGameRunner
    {
        IMiniGame MiniGame { get; }

        void Begin();
        bool Refresh();
        void End(bool isSuccess);
    }
}