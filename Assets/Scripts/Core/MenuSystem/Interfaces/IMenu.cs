namespace CIRC.Core.MenuSystem.Interfaces
{
    public interface IMenu
    {
        string MenuID { get; }
        bool IsOpen { get; }
        void Open();
        void Close();
    }
}