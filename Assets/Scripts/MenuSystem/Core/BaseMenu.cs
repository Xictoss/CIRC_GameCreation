using UnityEngine;

namespace CIRC.MenuSystem
{
    public abstract class BaseMenu : MonoBehaviour, MenuAttributes
    {
        public abstract void OpenMenu();
        public abstract void CloseMenu();
        
        public abstract MenuPriority Priority { get; }
        public abstract string MenuName { get; }
        public abstract GameObject Object { get; }
    }
}