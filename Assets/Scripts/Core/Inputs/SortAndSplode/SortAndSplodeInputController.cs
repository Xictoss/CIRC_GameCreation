using System;
using LTX.Singletons;
using NomDuJeu.Core;
using UnityEngine;
using UnityEngine.InputSystem;

namespace NomDuJeu.Inputs.SortAndSplode
{
    public class SortAndSplodeInputController : MonoSingleton<SortAndSplodeInputController>
    {
        #region Events

        public event Action<Collider2D> EntityDragged;
        public event Action<Collider2D> EntityReleased;

        #endregion
        
        private bool isDragging;
        private RaycastHit2D hit;
        
        public void GetTouchInput(InputAction.CallbackContext context)
        {
            hit = InputController.Instance.RayCastShoot("Default");
            
            if (context.performed) EnterClick();
            if (context.canceled && isDragging) ReleaseClick();
        }

        #region Click State

        private void EnterClick()
        {
            if (IsRaycastHitNull() || !IsRaycastHitEntity()) return;
            
            isDragging = true;
            EntityDragged?.Invoke(hit.collider);
        }

        private void ReleaseClick()
        {
            isDragging = false;
            EntityReleased?.Invoke(hit.collider);
        }

        #endregion

        #region RayCastHitTypeCheck

        private bool IsRaycastHitEntity() => hit.collider.CompareTag("MiniGameEntity");
        private bool IsRaycastHitNull() => !hit.collider;

        #endregion
    }
}