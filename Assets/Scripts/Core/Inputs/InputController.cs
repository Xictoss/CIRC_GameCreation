using System;
using LTX.Singletons;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace CIRC.Core.Inputs
{
    public class InputController : MonoSingleton<InputController>
    {
        [Header("Long Press")]
        private float touchStartTime;
        
        [Header("Swipe")]
        private Vector2 startPosition;
        private bool isSwiping = false;
        private const float swipeThreshold = 50f;
        
        [Header("Double Touch")]
        private float lastTapTime = 0f;
        private const float doubleTapThreshold = 0.2f;
        
        public event Action<bool> OnClickInput;
        public event Action<float> OnLongClickInput;
        public event Action<bool> OnDoubleClickInput;
        public event Action<Vector2> OnSwipeInput;
        
        public Vector3 WorldTouchPosition { get; private set; }
        public Vector3 ScreenTouchPosition { get; private set; }
        
        private PointerEventData _pointerEventData;
        [SerializeField] private GraphicRaycaster _graphicRaycaster;
        [SerializeField] private EventSystem _eventSystem;

        public void GetTouchPositionInput(InputAction.CallbackContext context)
        {
            Vector2 touchInput = context.ReadValue<Vector2>();
            ScreenTouchPosition = new Vector3(touchInput.x, touchInput.y, 0f);
            WorldTouchPosition = ScreenTouchPosition.FromScreenPointToWorldPoint();
        }
        
        public void GetTouchInput(InputAction.CallbackContext context)
        {
            OnClickInput?.Invoke(context.performed);
            
            if (context.started)
            {
                touchStartTime = Time.time;
            }
            else if (context.canceled)
            {
                OnLongClickInput?.Invoke(Time.time - touchStartTime);
            }
        }
        
        public void GetDoubleTouchInput(InputAction.CallbackContext context)
        {
            float currentTime = Time.time;
            if (context.started)
            {
                if (currentTime - lastTapTime <= doubleTapThreshold)
                {
                    lastTapTime = 0f;
                    OnDoubleClickInput?.Invoke(true);
                }
                else
                {
                    lastTapTime = currentTime;
                }
            }
        }
        
        public void GetSwipeInput(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                startPosition = ScreenTouchPosition;
                isSwiping = true;
            }
            else if (context.canceled)
            {
                if (isSwiping)
                {
                    Vector2 endPosition = ScreenTouchPosition;
                    Vector2 swipeDelta = endPosition - startPosition;

                    if (swipeDelta.magnitude > swipeThreshold)
                    {
                        Vector2 direction = swipeDelta.normalized;
                        OnSwipeInput?.Invoke(direction);
                    }
                }
                isSwiping = false;
            }
        }
        
        public RaycastHit2D RayCastToWorld(string layerMaskName)
        {
            Ray ray = Camera.main!.ScreenPointToRay(ScreenTouchPosition);
            RaycastHit2D raycastHit = Physics2D.Raycast(ray.origin, ray.direction, 100f, LayerMask.GetMask(layerMaskName));
            return raycastHit;
        }
    }
}