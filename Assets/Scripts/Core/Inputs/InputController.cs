using LTX.Singletons;
using UnityEngine;
using UnityEngine.InputSystem;

namespace NomDuJeu.Core
{
    public class InputController : MonoSingleton<InputController>
    {
        public Vector3 worldTouchPosition { get; private set; }
        private Vector3 screenTouchPosition;

        protected override void Awake()
        {
            base.Awake();
        }

        public void GetTouchPositionInput(InputAction.CallbackContext context)
        {
            Vector2 touchPosition = context.ReadValue<Vector2>();
            screenTouchPosition = new Vector3(touchPosition.x, touchPosition.y, 0f);
            worldTouchPosition = Camera.main!.ScreenToWorldPoint(screenTouchPosition);

            worldTouchPosition = new Vector3(worldTouchPosition.x, worldTouchPosition.y, 0f);
            
            //Debug.Log(touchPosition);
        }
        
        public RaycastHit2D RayCastShoot(string layerMaskName)
        {
            Ray ray = Camera.main!.ScreenPointToRay(screenTouchPosition);
            RaycastHit2D raycastHit = Physics2D.Raycast(ray.origin, ray.direction, 100f, LayerMask.GetMask(layerMaskName));
            return raycastHit;
        }
    }
}
