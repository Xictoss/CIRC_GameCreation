using System.Collections.Generic;
using LTX.Singletons;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace CIRC.Core.Inputs
{
    public class InputController : MonoSingleton<InputController>
    {
        public Vector3 WorldTouchPosition { get; private set; }
        public Vector3 ScreenTouchPosition { get; private set; }
        
        private PointerEventData _pointerEventData;
        [SerializeField] private GraphicRaycaster _graphicRaycaster;
        [SerializeField] private EventSystem _eventSystem;

        public void GetTouchPositionInput(InputAction.CallbackContext context)
        {
            Vector2 touchInput = context.ReadValue<Vector2>();
            ScreenTouchPosition = new Vector3(touchInput.x, touchInput.y, 0f);
            WorldTouchPosition = ScreenTouchPosition.FromScreenPointToWorldPoint();
        }
        
        public RaycastHit2D RayCastToWorld(string layerMaskName)
        {
            Ray ray = Camera.main!.ScreenPointToRay(ScreenTouchPosition);
            RaycastHit2D raycastHit = Physics2D.Raycast(ray.origin, ray.direction, 100f, LayerMask.GetMask(layerMaskName));
            return raycastHit;
        }
        
        public GameObject RaycastToUI()
        {
            _pointerEventData = new PointerEventData(_eventSystem)
            {
                position = Pointer.current.position.ReadValue()
            };

            List<RaycastResult> results = new List<RaycastResult>();
            _graphicRaycaster.Raycast(_pointerEventData, results);
            
            foreach (var result in results)
            {
                if (result.gameObject.layer == LayerMask.NameToLayer("Ignore Raycast")) continue;
                
                return result.gameObject;
            }

            return null;
        }
    }
}