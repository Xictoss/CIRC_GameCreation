using System;
using LTX.Singletons;
using UnityEngine;

namespace CIRC.Core.Inputs.SortAndSplode
{
    public class SortAndSplodeInputController : MonoSingleton<SortAndSplodeInputController>
    {
        #region Events

        public event Action<GameObject> EntityDragged;
        public event Action<GameObject> EntityReleased;

        #endregion
        
        private bool _isDragging;
        private GameObject _selectedUIElement;

        private void OnEnable()
        {
            InputController.Instance.OnClickInput += GetTouchInput;
        }
        
        private void OnDisable()
        {
            InputController.Instance.OnClickInput -= GetTouchInput;
        }
        
        public void GetTouchInput(bool inputState)
        {
            _selectedUIElement = InputController.Instance.RaycastToUI();
            
            switch (inputState)
            {
                case true:
                    EnterClick();
                    break;
                case false when _isDragging:
                    ReleaseClick();
                    break;
            }
        }
        

        #region Click State

        private void EnterClick()
        {
            _isDragging = true;
            EntityDragged?.Invoke(_selectedUIElement); //Entity
        }

        private void ReleaseClick()
        {
            _isDragging = false;
            EntityReleased?.Invoke(_selectedUIElement); //End Zone
        }

        #endregion
    }
}