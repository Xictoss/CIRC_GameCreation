using UnityEngine;

namespace CIRC.Core.MenuSystem
{
    public class PanelOpen : MonoBehaviour
    {
        private bool isOpen;
        public void SwitchPanelState(GameObject obj)
        {
            isOpen = !isOpen;
            obj.SetActive(isOpen);
        }
    }
}