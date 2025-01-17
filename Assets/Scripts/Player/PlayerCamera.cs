using CIRC.Inputs;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CIRC.Player
{
    public class PlayerCamera : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Camera cam;
        [SerializeField] private Transform camHolder;
        
        [Header("Drag Parameters")]
        [SerializeField, Range(0, 1)] private float smoothSpeed;
        [SerializeField] private Vector2 minMaxX, minMaxY;

        private Vector3 origin, difference;
        private bool isDragging;
        private bool primaryTouch, secondaryTouch;
        
        private void OnEnable()
        {
            InputController.Instance.OnPrimaryClickInput += GetPrimaryClick;
            InputController.Instance.OnPrimaryClickInput += GetSecondaryClick;
        }
        
        private void OnDisable()
        {
            InputController.Instance.OnPrimaryClickInput -= GetPrimaryClick;
            InputController.Instance.OnPrimaryClickInput -= GetSecondaryClick;
        }

        private Vector3 GetPrimaryTouchPosition => InputController.Instance.WorldTouchPosition;
        private void GetPrimaryClick(InputAction.CallbackContext context)
        {
            if (context.started) origin = GetPrimaryTouchPosition;

            isDragging = context.started || context.performed;
            primaryTouch = context.started || context.performed;
        }
        
        private Vector3 GetSecondaryTouchPosition => InputController.Instance.SecondWorldTouchPosition;
        private void GetSecondaryClick(InputAction.CallbackContext context)
        {
            if (context.started) origin = GetPrimaryTouchPosition;

            secondaryTouch = context.started || context.performed;
        }

        private void LateUpdate()
        {
            HandleDrag();
            HandleZooming();
        }

        private void HandleDrag()
        {
            //Calculate
            if (isDragging) difference = GetPrimaryTouchPosition - camHolder.transform.localPosition;
            
            //Move
            camHolder.transform.localPosition = Vector3.Lerp(
                camHolder.transform.localPosition, 
                origin - difference, 
                1 - Mathf.Exp(-smoothSpeed));
            
            //Clamp
            camHolder.transform.localPosition = new Vector3(
                Mathf.Clamp(camHolder.transform.localPosition.x, minMaxX.x, minMaxX.y),
                Mathf.Clamp(camHolder.transform.localPosition.y, minMaxY.x, minMaxY.y),
                0f);
        }

        private void HandleZooming()
        {
            
        }
    }
}