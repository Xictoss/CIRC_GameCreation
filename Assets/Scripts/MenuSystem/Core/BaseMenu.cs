using UnityEngine;

namespace CIRC.MenuSystem
{
    public abstract class BaseMenu : MonoBehaviour, MenuAttributes
    {
        public virtual void OpenMenu()
        {
            gameObject.SetActive(true);
        }

        public virtual void CloseMenu()
        {
            gameObject.SetActive(false);
        }
        
        public virtual MenuPriority Priority => MenuPriority.Medium;
        public abstract string MenuName { get; }
        public virtual GameObject Object => gameObject;
    }
}