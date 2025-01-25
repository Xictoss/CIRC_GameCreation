using UnityEngine;

namespace CIRC.MenuSystem
{
    public interface MenuAttributes
    {
        public MenuPriority Priority { get; }
        public GameObject Object { get; }
    }
}