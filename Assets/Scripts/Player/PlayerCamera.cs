using CIRC.Inputs;
using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

namespace CIRC.Player
{
    public class PlayerCamera : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Camera cam;
        [SerializeField] private Transform camHolder;
        
        [Header("Drag Parameters")]
        [SerializeField, Range(0, 1)] private float dragSmoothSpeed;
        [SerializeField] private Vector2 minMaxX, minMaxY;
        private InputAction.CallbackContext dragContext;
        
        [Header("Zoom Parameters")]
        [SerializeField, Range(0, 1)] private float zoomSmoothSpeed;
        [SerializeField] private Vector2 zoomMinMax;
        private bool isZooming;
        private float previousDistance;

        private Vector3 origin, difference;
        private bool primaryTouch, secondaryTouch;
        
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

        private Vector3 GetPrimaryWorldPosition => InputController.Instance.WorldTouchPosition;
        private Vector2 GetPrimaryScreenPosition => InputController.Instance.ScreenTouchPosition;
        private void GetPrimaryClick(InputAction.CallbackContext context)
        {
            if (context.started) origin = GetPrimaryWorldPosition;

            primaryTouch = context.started || context.performed;
        }
        
        private Vector3 GetSecondaryWorldPosition => InputController.Instance.SecondWorldTouchPosition;
        private Vector2 GetSecondaryScreenPosition => InputController.Instance.SecondScreenTouchPosition;
        private void GetSecondaryClick(InputAction.CallbackContext context)
        {
            secondaryTouch = context.started || context.performed;
        }

        private void LateUpdate()
        {
            HandleDrag();
            HandleZooming();
        }

        private void HandleDrag()
        {
            if (TwoTouch) return;

            //Calculate
            if (primaryTouch) 
            {
                if (isZooming) 
                {
                    origin = GetPrimaryWorldPosition;
                }
                
                difference = origin - camHolder.transform.localPosition;
            }
            
            //Move | way n°1
            camHolder.transform.localPosition = Vector3.Lerp(
                camHolder.transform.localPosition, 
                origin - difference, 
                dragSmoothSpeed);
          
            //Move | way n°2
            //camHolder.transform.DOLocalMove(origin - difference, dragSmoothSpeed);
            
            //Clamp
            camHolder.transform.localPosition = new Vector3(
                Mathf.Clamp(camHolder.transform.localPosition.x, minMaxX.x, minMaxX.y),
                Mathf.Clamp(camHolder.transform.localPosition.y, minMaxY.x, minMaxY.y),
                0f);
        }

        private bool TwoTouch => primaryTouch && secondaryTouch;
        private void HandleZooming()
        {
            if (TwoTouch)
            {
                //Calculate Distance
                float currentDistance = Vector3.Distance(GetPrimaryWorldPosition, GetSecondaryWorldPosition);
                
                if (!isZooming)
                {
                    previousDistance = currentDistance;
                    isZooming = true;
                }
                else
                {
                    // Calculate zoom factor 
                    float deltaDistance = currentDistance - previousDistance;
                    
                    // Lerp Zoom
                    cam.orthographicSize = Mathf.Lerp(
                        cam.orthographicSize,
                        cam.orthographicSize - deltaDistance,
                        zoomSmoothSpeed);
                    
                    // Clamp zoom 
                    cam.orthographicSize = Mathf.Clamp(
                        cam.orthographicSize,
                        zoomMinMax.x,  
                        zoomMinMax.y);

                    previousDistance = currentDistance;
                }
            }
            else
            {
                isZooming = false;
            }
        }
    }
}