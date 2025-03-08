using CIRC.Collections;
using UnityEngine;

namespace CIRC.MenuSystem
{
    public interface MenuAttributes
    {
        public PriorityScale PriorityScale { get; }
        public GameObject Object { get; }
    }
}