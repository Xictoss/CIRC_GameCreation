using LTX.Singletons;
using UnityEngine;
using UnityEngine.InputSystem;

namespace NomDuJeu.Core
{
    public class InputController : MonoSingleton<InputController>
    {
        public Vector3 worldTouchPosition { get; private set; }
        public Vector3 screenTouchPosition { get; private set; }

        public void GetTouchPositionInput(InputAction.CallbackContext context)
        {
            Vector2 touchInput = context.ReadValue<Vector2>();
            screenTouchPosition = new Vector3(touchInput.x, touchInput.y, 0f);

            if (Camera.main != null) worldTouchPosition = Camera.main.ScreenToWorldPoint(screenTouchPosition);
            worldTouchPosition = new Vector3(worldTouchPosition.x, worldTouchPosition.y, 0f);
        }
        
        public RaycastHit2D RayCastShoot(string layerMaskName)
        {
            Ray ray = Camera.main!.ScreenPointToRay(screenTouchPosition);
            RaycastHit2D raycastHit = Physics2D.Raycast(ray.origin, ray.direction, 100f, LayerMask.GetMask(layerMaskName));
            return raycastHit;
        }
    }
}