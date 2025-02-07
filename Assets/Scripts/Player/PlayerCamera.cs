using CIRC.Inputs;
using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CIRC.Player
{
    public class PlayerCamera : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Camera cam;

        [Header("Drag Parameters")] 
        [SerializeField] private Vector2 minMaxX;
        [SerializeField] private Vector2 minMaxY; 
        [SerializeField] private float sensitivity = 0.03f;
        [SerializeField, Range(0, 1)] private float smoothMove = 0.5f;
        private Vector3 initialTouchPosition, currentTouchPosition;
        
        private void OnEnable()
        {
            InputController.Instance.OnPrimaryClickInput += GetFirstInput;
            InputController.Instance.OnSecondClickInput += GetSecondInput;
        }
        
        private void OnDisable()
        {
            InputController.Instance.OnPrimaryClickInput -= GetFirstInput;
            InputController.Instance.OnSecondClickInput -= GetSecondInput;
        }

        private Vector3 GetFirstTouch => InputController.Instance.ScreenTouchPosition;
        private void GetFirstInput(InputAction.CallbackContext context)
        {
            if (context.started || context.performed)
            {
                initialTouchPosition = GetFirstTouch;
            }
            else if (context.canceled)
            {
                
            }
        }
        
        private Vector3 GetSecondTouch => InputController.Instance.SecondScreenTouchPosition;
        private void GetSecondInput(InputAction.CallbackContext context)
        {
            
        }

        private void Update()
        {
            MoveCamera();
        }

        private void MoveCamera()
        {
            currentTouchPosition = GetFirstTouch;
            
            Vector3 deltaPosition = currentTouchPosition - initialTouchPosition;
            Vector3 targetPosition = cam.transform.localPosition + new Vector3(-deltaPosition.x, -deltaPosition.y, 0) * sensitivity;
            
            cam.transform.localPosition = Vector3.Lerp(cam.transform.localPosition, targetPosition, smoothMove);
            
            Debug.Log(Mathf.Clamp(cam.transform.localPosition.x, minMaxX.x, minMaxX.y));
            
            /*
            cam.transform.position = new Vector3(
                Mathf.Clamp(cam.transform.position.x, minMaxX.x, minMaxX.y),
                Mathf.Clamp(cam.transform.position.y, minMaxY.x, minMaxY.y),
                -100
            );
            */
            
            initialTouchPosition = currentTouchPosition;
        }
    }
}