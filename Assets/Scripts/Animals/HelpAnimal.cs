using CIRC.Controllers;
using CIRC.MenuSystem;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CIRC.Animals
{
    public class HelpAnimal : MonoBehaviour, IPointerClickHandler
    {
        public void OnPointerClick(PointerEventData eventData)
        {
            MenuManager.Instance.TryOpenMenu(GameController.Metrics.MiniGamePopUpMenu);
        }
    }
}