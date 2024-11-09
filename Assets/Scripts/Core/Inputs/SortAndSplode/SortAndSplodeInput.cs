using System;
using LTX.Singletons;
using NomDuJeu.Core;
using UnityEngine;
using UnityEngine.InputSystem;

namespace NomDuJeu.Inputs.SortAndSplode
{
    public class SortAndSplodeInput : MonoSingleton<SortAndSplodeInput>
    {
        public event Action<GameObject> EntityDragged;
        public event Action<GameObject> EntityReleased;
        public event Action EntityReleasedOnEmpty;
        private bool isDragging;

        private GameObject draggedObject;
        private RaycastHit2D hit;

        protected override void Awake()
        {
            base.Awake();
        }
        
        public void GetTouchInput(InputAction.CallbackContext context)
        {
            if (context.performed) HandleRaycast(true);
            if (context.canceled && isDragging) HandleRaycast(false);
        }
        
        private void HandleRaycast(bool isTouch)
        {
            hit = InputController.Instance.RayCastShoot("Default");

            if (isTouch)
            {
                if (hit.collider != null && hit.collider.CompareTag("MiniGameEntity"))
                {
                    isDragging = true;
                    draggedObject = hit.collider.gameObject;
                    //Debug.Log("Hit object: " + draggedObject.name);
                    EntityDragged?.Invoke(draggedObject);
                }
            }
            else // Release
            {
                isDragging = false;
                if (hit.collider == null || hit.collider.CompareTag("MiniGameEntity"))
                {
                    EntityReleasedOnEmpty?.Invoke();
                }
                else
                {
                    //Debug.Log("Release Zone: " + hit.collider.gameObject.name);
                    EntityReleased?.Invoke(hit.collider.gameObject);
                }
            }
        }
    }
}