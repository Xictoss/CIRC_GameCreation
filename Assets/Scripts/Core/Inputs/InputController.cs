using System;
using LTX.Singletons;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CIRC.Core.Inputs
{
    public class InputController : MonoSingleton<InputController>
    {
        [Header("Long Press")]
        private float touchStartTime;
        
        [Header("Swipe")]
        [SerializeField] private float swipeThreshold = 50f;
        private Vector2 startPosition;
        private bool isSwiping = false;
        
        [Header("Double Touch")]
        [SerializeField] private float doubleTapThreshold = 0.2f;
        private float lastTapTime = 0f;
        
        [Header("Shake Phone")]
        [SerializeField] private float shakeThreshold = 2.0f;
        [SerializeField] private float shakeCooldown = 0.5f;
        private Vector3 lastAcceleration;
        private float lastShakeTime;
        
        public event Action<bool> OnClickInput;
        public event Action<float> OnLongClickInput;
        public event Action<bool> OnDoubleClickInput;
        public event Action<Vector2> OnSwipeInput;
        public event Action<Vector3> OnShakeInput;
        
        public Vector3 WorldTouchPosition { get; private set; }
        public Vector3 ScreenTouchPosition { get; private set; }

        protected override void Awake()
        {
            base.Awake();
            
            InputSystem.EnableDevice(Accelerometer.current);
        }
        
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
                        Debug.Log("swipe");
                    }
                }
                isSwiping = false;
            }
        }
        
        private void OnEnable()
        {

            accelerometerAction = inputActions.actionMaps[0].FindAction("Shake");
            if (accelerometerAction != null)
            {
                accelerometerAction.Enable();
            }
            
            lastAcceleration = Vector3.zero;
        }

        private void OnDisable()
        {
            if (accelerometerAction != null)
            {
                accelerometerAction.Disable();
            }
        }

        public InputActionAsset inputActions;
        private InputAction accelerometerAction;
        private void Update()
        {
            Vector3 currentAcceleration = accelerometerAction.ReadValue<Vector3>();
            Vector3 accelerationDelta = currentAcceleration - lastAcceleration;
            
            if (accelerationDelta.sqrMagnitude > shakeThreshold * shakeThreshold)
            {
                if (Time.time - lastShakeTime > shakeCooldown)
                {
                    Debug.Log("Shake Detected");
                    OnShakeInput?.Invoke(accelerationDelta);
                    lastShakeTime = Time.time;
                }
            }
            
            lastAcceleration = currentAcceleration;
        }
        
        public RaycastHit2D RayCastToWorld(string layerMaskName)
        {
            Ray ray = UnityEngine.Camera.main!.ScreenPointToRay(ScreenTouchPosition);
            RaycastHit2D raycastHit = Physics2D.Raycast(ray.origin, ray.direction, 100f, LayerMask.GetMask(layerMaskName));
            return raycastHit;
        }
    }
}