using System;
using LTX.Singletons;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CIRC.Inputs
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
        
        public event Action<InputAction.CallbackContext> OnPrimaryClickInput;
        public event Action<InputAction.CallbackContext> OnSecondClickInput;
        public event Action<float> OnLongClickInput;
        public event Action<bool> OnDoubleClickInput;
        public event Action<Vector2> OnSwipeInput;
        public event Action<Vector3> OnShakeInput;
        
        public Vector3 WorldTouchPosition { get; private set; }
        public Vector2 ScreenTouchPosition { get; private set; }
        
        public Vector3 SecondWorldTouchPosition { get; private set; }
        public Vector2 SecondScreenTouchPosition { get; private set; }

        protected override void Awake()
        {
            base.Awake();
            
            InputSystem.EnableDevice(Accelerometer.current);
        }
        
        public void GetTouchPositionInput(InputAction.CallbackContext context)
        {
            Vector2 touchInput = context.ReadValue<Vector2>();
            ScreenTouchPosition = touchInput;
            WorldTouchPosition = StaticFunctions.FromScreenPointToWorldPoint(ScreenTouchPosition);
        }
        
        public void GetSecondTouchPositionInput(InputAction.CallbackContext context)
        {
            Vector2 touchInput = context.ReadValue<Vector2>();
            SecondScreenTouchPosition = touchInput;
            SecondWorldTouchPosition = StaticFunctions.FromScreenPointToWorldPoint(SecondScreenTouchPosition);
        }
        
        public void GetTouchInput(InputAction.CallbackContext context)
        {
            OnPrimaryClickInput?.Invoke(context);
            
            if (context.started)
            {
                touchStartTime = Time.time;
            }
            else if (context.canceled)
            {
                OnLongClickInput?.Invoke(Time.time - touchStartTime);
            }
        }
        
        public void GetSecondTouchInput(InputAction.CallbackContext context)
        {
            OnSecondClickInput?.Invoke(context);
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
            AccelerometerInput();
            Swipe();
        }

        private void Swipe()
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
            else
            {
                OnSwipeInput?.Invoke(Vector2.zero);
            }
        }

        private void AccelerometerInput()
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
    }
}