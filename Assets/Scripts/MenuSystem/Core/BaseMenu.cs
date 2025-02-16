using UnityEngine;

namespace CIRC.MenuSystem
{
    public abstract class BaseMenu : MonoBehaviour, MenuAttributes
    {
        public virtual void OpenMenu(MenuContext ctx)
        {
            gameObject.SetActive(true);
        }

        public virtual void CloseMenu()
        {
            gameObject.SetActive(false);
        }
        
        public virtual PriorityScale PriorityScale => PriorityScale.Medium;
        public abstract string MenuName { get; }
        public virtual GameObject Object => gameObject;
    }
}