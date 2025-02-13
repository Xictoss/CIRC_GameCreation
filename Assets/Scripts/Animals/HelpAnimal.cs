using System.Collections;
using CIRC.Controllers;
using CIRC.MenuSystem;
using CIRC.Player;
using CIRC.Progression;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CIRC.Animals
{
    public class HelpAnimal : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private MiniGameDataHolder data;
        [SerializeField] private AnimationCurve curve;
        
        public void OnPointerClick(PointerEventData eventData)
        {
            float speed = 1;
            
            PlayerCamera.Instance.FocusToPoint(transform.position + new Vector3(0, 2, 0), 0.15f, speed, curve);
            
            StartCoroutine(OpenMenuAfterDelay(speed));
        }

        private IEnumerator OpenMenuAfterDelay(float delay)
        {
            yield return new WaitForSeconds(delay);
            OpenMenu();
        }

        private void OpenMenu()
        {
            MenuContext ctx = new MenuContext()
            {
                title = data.miniGameTitle,
                desc = data.miniGameDesc
            };
            
            MenuManager.Instance.TryOpenMenu(GameController.Metrics.MiniGamePopUpMenu, ctx, 0.1f);
        }
    }
}