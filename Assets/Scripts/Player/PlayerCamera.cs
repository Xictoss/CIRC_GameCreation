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
        [SerializeField, Range(0.01f, 0.5f)] private float dragSmoothTime = 0.1f;
        [SerializeField] private Vector2 horizontalLimits = new(-10, 10);
        [SerializeField] private Vector2 verticalLimits = new(-10, 10);
        private Vector3 previousPrimaryClick;
        
        [Header("Zoom Parameters")]
        [SerializeField, Range(0.01f, 1f)] private float zoomSensitivity = 0.1f;
        [SerializeField, Range(0.01f, 0.5f)] private float zoomSmoothTime = 0.1f;
        [SerializeField] private Vector2 zoomLimits = new(5, 20);
        [SerializeField] private float minPinchDistance = 50f;
        private Vector2 firstTouchPreviousPos;
        private Vector2 secondTouchPreviousPos;

        private Vector3 dragOrigin;
        private Vector3 velocity = Vector3.zero;
        private float zoomVelocity;
        private bool isDragging;
        private bool isZooming;
        
        private void OnEnable()
        {
            InputController.Instance.OnPrimaryClickInput += GetPrimaryClick;
            InputController.Instance.OnSecondClickInput += GetSecondaryClick;
        }
        
        private void OnDisable()
        {
            InputController.Instance.OnPrimaryClickInput -= GetPrimaryClick;
            InputController.Instance.OnSecondClickInput -= GetSecondaryClick;
        }

        private Vector3 GetWorldTouchPosition => InputController.Instance.ScreenTouchPosition;
        private void GetPrimaryClick(InputAction.CallbackContext context)
        {
            if (context.started || context.performed)
            {
                dragOrigin = GetWorldTouchPosition;
                previousPrimaryClick = dragOrigin;
                isDragging = true;
            }
            else if (context.canceled)
            {
                isDragging = false;
            }
        }
        
        private Vector3 GetSecondaryWorldPosition => InputController.Instance.SecondScreenTouchPosition;
        private void GetSecondaryClick(InputAction.CallbackContext context)
        {
            isZooming = context.started || context.performed;
        }

        private void Update()
        {
            if (isZooming)
            {
                HandleZooming();
            }
            else if (isDragging)
            {
                HandleCameraDrag();
            }
        }

        private void HandleCameraDrag()
        {
            Vector3 currentPosition = GetWorldTouchPosition;
            Vector3 delta = currentPosition - previousPrimaryClick;
            
            // Smooth damping movement
            camHolder.localPosition = Vector3.SmoothDamp(
                camHolder.localPosition,
                camHolder.localPosition - delta,
                ref velocity,
                dragSmoothTime);
            
            //Clamp
            camHolder.localPosition = new Vector3(
                Mathf.Clamp(camHolder.localPosition.x, horizontalLimits.x, horizontalLimits.y),
                Mathf.Clamp(camHolder.localPosition.y, verticalLimits.x, verticalLimits.y),
                0f);

            previousPrimaryClick = currentPosition;
        }

        private void HandleZooming()
        {
            if (!isZooming) return;

            // Calculate distances
            float previousDistance = Vector2.Distance(firstTouchPreviousPos, secondTouchPreviousPos);
            float currentDistance = Vector2.Distance(GetWorldTouchPosition, GetSecondaryWorldPosition);

            // Only zoom if fingers moved beyond minimum threshold
            if (Mathf.Abs(currentDistance - previousDistance) > minPinchDistance)
            {
                float zoomDelta = (currentDistance - previousDistance) * zoomSensitivity;
                ApplyZoom(zoomDelta);
            }

            // Store positions for next frame
            firstTouchPreviousPos = GetWorldTouchPosition;
            secondTouchPreviousPos = GetSecondaryWorldPosition;
        }

        private void ApplyZoom(float zoomDelta)
        {
            float targetSize = cam.orthographicSize - zoomDelta;
            
            cam.orthographicSize = Mathf.SmoothDamp(
                cam.orthographicSize,
                Mathf.Clamp(targetSize, zoomLimits.x, zoomLimits.y),
                ref zoomVelocity,
                zoomSmoothTime
            );
        }
    }
}