using System;
using LTX.Singletons;
using UnityEngine;
using UnityEngine.InputSystem;

namespace NomDuJeu.Core
{
    public class InputController : MonoSingleton<InputController>
    {
        public Vector3 worldTouchPosition { get; private set; }
        private Vector3 screenTouchPosition;

        public event Action<GameObject> EntityDragged;
        public event Action<GameObject> EntityReleased;
        public event Action EntityReleasedOnEmpty;
        private bool isDragging;

        private GameObject draggedObject;

        private new Camera camera;
        
        protected override void Awake()
        {
            base.Awake();
            camera = Camera.main;
        }

        public void GetTouchPositionInput(InputAction.CallbackContext context)
        {
            Vector2 touchPosition = context.ReadValue<Vector2>();
            screenTouchPosition = new Vector3(touchPosition.x, touchPosition.y, 0f);
            worldTouchPosition = camera.ScreenToWorldPoint(screenTouchPosition);

            worldTouchPosition = new Vector3(worldTouchPosition.x, worldTouchPosition.y, 0f);
            
            //Debug.Log(touchPosition);
        }

        public void GetTouchInput(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                TouchRaycast();
            }
            else if (context.canceled && isDragging)
            {
                ReleaseRaycast();
            }
        }

        private void TouchRaycast()
        {
            RaycastHit2D hit = RayCastShoot();

            if (hit.collider == null || !hit.collider.CompareTag("MiniGameEntity")) return;
            isDragging = true;
            
            draggedObject = hit.collider.gameObject;
            //Debug.Log("Hit object: " + draggedObject.name);
            
            EntityDragged?.Invoke(draggedObject);
        }

        private void ReleaseRaycast()
        {
            isDragging = false;
            
            RaycastHit2D hit = RayCastShoot();

            if (hit.collider == null || hit.collider.CompareTag("MiniGameEntity"))
            {
                EntityReleasedOnEmpty?.Invoke();
                return;
            }
            
            //Debug.Log("Release Zone: " + hit.collider.gameObject.name);
            
            EntityReleased?.Invoke(hit.collider.gameObject);
        }

        private RaycastHit2D RayCastShoot()
        {
            Ray ray = camera.ScreenPointToRay(screenTouchPosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, 100f, LayerMask.GetMask("Default"));
            return hit;
        }
    }
}
