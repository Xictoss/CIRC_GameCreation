using System.Collections;
using CIRC.CameraScripts;
using CIRC.Controllers;
using CIRC.MenuSystem;
using CIRC.Progression;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CIRC.Animals
{
    public class HelpAnimal : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private MiniGameDataHolder data;
        [SerializeField] private AnimationCurve curve;
        private bool canClick = true;
        
        public void OnPointerClick(PointerEventData eventData)
        {
            if (!canClick) return;
            
            canClick = false;
            float speed = 1;

            if (Vector3.Distance(PlayerCamera.Instance.cameraTarget.position,
                    transform.position + new Vector3(0, 2, 0)) <= 0.1f)
            {
                OpenMenu();
                return;
            }
            else
            {
                PlayerCamera.Instance.FocusToPoint(transform.position + new Vector3(0, 2, 0), 0.15f, speed, curve);
            }
            
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
            
            MenuManager.Instance.TryOpenMenu(GameController.Metrics.MiniGamePopUpMenu, ctx);
            canClick = true;
        }
    }
}