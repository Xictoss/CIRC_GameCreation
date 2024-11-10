using System;
using LTX.Singletons;
using NomDuJeu.Inputs.Core;
using UnityEngine;
using UnityEngine.InputSystem;

namespace NomDuJeu.Inputs.SortAndSplode
{
    public class SortAndSplodeInputController : MonoSingleton<SortAndSplodeInputController>
    {
        #region Events

        public event Action<GameObject> EntityDragged;
        public event Action<GameObject> EntityReleased;

        #endregion
        
        private bool _isDragging;
        private GameObject _selectedUIElement;

        public void GetTouchInput(InputAction.CallbackContext context)
        {
            _selectedUIElement = InputController.Instance.RaycastToUI();
            
            if (context.performed) EnterClick();
            if (context.canceled && _isDragging) ReleaseClick();
        }

        #region Click State

        private void EnterClick()
        {
            _isDragging = true;
            EntityDragged?.Invoke(_selectedUIElement);
        }

        private void ReleaseClick()
        {
            _isDragging = false;
            EntityReleased?.Invoke(_selectedUIElement);
        }

        #endregion
    }
}