using System;
using CIRC.Controllers;
using CIRC.Inputs;
using CIRC.MenuSystem;
using DG.Tweening;
using LTX.Singletons;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace CIRC.CameraScripts
{
    public class PlayerCamera : MonoSingleton<PlayerCamera>
    {
        private static InputController InputController => InputController.Instance;

        [Header("References")]
        [field: SerializeField] public Transform cameraTarget { get; private set; }
        [SerializeField] private CinemachineRecomposer recomposer;
        
        [Header("Drag Parameters")] 
        [SerializeField] private Bounds cameraMoveRange;
        [SerializeField] private float smoothClampSpeed = 15f;
        private Vector3 targetSwipePos;

        [Header("Zoom Parameters")] 
        [SerializeField] private Vector2 zoomClamp = new Vector2(0.2f, 2);
        [SerializeField] private float smoothZoomSpeed = 15f;
        [SerializeField] private float zoomSensitivity = 0.1f;
        [SerializeField] private float zoomMoveSpeed = 0.3f;
        private float previousDistance, currentDistance;
        private bool secondTouch;
        private InputAction primaryTouch, secondaryTouch;
        private Vector3 zoomMiddlePoint;

        public void FocusToPoint(Vector3 point, float zoomPoint, float speed, AnimationCurve curve)
        {
            cameraTarget.DOMove(point, speed).SetEase(curve);
            
            DOTween.To(
                () => recomposer.ZoomScale,
                x => recomposer.ZoomScale = x,
                zoomPoint,
                speed)
                .SetEase(curve);
        }

        private void OnEnable()
        {
            SceneManager.sceneLoaded += SceneManagerOnsceneLoaded;
        }
        
        private void OnDisable()
        {
            SceneManager.sceneLoaded -= SceneManagerOnsceneLoaded;
        }

        private void SceneManagerOnsceneLoaded(Scene arg0, LoadSceneMode arg1)
        {
            if (CameraController.Global.CameraAttributes.cameraPosition == Vector3.zero) return;
            
            cameraTarget.position = CameraController.Global.CameraAttributes.cameraPosition;
            recomposer.ZoomScale = CameraController.Global.CameraAttributes.cameraZoom;
        }

        private void Update()
        {
            if (MenuManager.Instance.currentMenu == null && !UIBlocker.Instance.IsPointerOverUI())
            {
                MoveCamera();
                ClampCamera();

                CalculateZoomInputs();
                ZoomCamera();
                
                GameController.CameraController.SetCameraState(cameraTarget.position, recomposer.ZoomScale);
            }
        }

        private void ClampCamera()
        {
            if (!cameraMoveRange.Contains(cameraTarget.position))
            {
                Vector3 clampedPosition = new Vector3(
                    Mathf.Clamp(cameraTarget.position.x, cameraMoveRange.min.x, cameraMoveRange.max.x),
                    cameraTarget.position.y,
                    Mathf.Clamp(cameraTarget.position.z, cameraMoveRange.min.z, cameraMoveRange.max.z)
                );

                cameraTarget.position = Vector3.Lerp(cameraTarget.position, clampedPosition, smoothClampSpeed * Time.deltaTime);
            }
        }

        private void MoveCamera()
        {
            if (secondTouch) return;
            
            Vector2 delta = InputController.PlayerInputActions.TouchScreen.Swipe.ReadValue<Vector2>();
            Vector2 centerScreen = new Vector2(Screen.width * .5f, Screen.height * .5f);

            Vector3 centerPos = StaticFunctions.FromScreenPointToWorldPoint(centerScreen);
            Vector3 offsetPos = StaticFunctions.FromScreenPointToWorldPoint(centerScreen + delta);

            Vector3 worldDelta = offsetPos - centerPos;
            worldDelta.y = 0;
            
            cameraTarget.Translate(-worldDelta);
        }

        private void CalculateZoomInputs()
        {
            primaryTouch = InputController.PlayerInputActions.TouchScreen.TouchPosition;
            secondaryTouch = InputController.PlayerInputActions.TouchScreen.SecTouchPosition;
            
           InputAction secTouch = InputController.PlayerInputActions.TouchScreen.SecondTouch;

            if (secTouch.phase == InputActionPhase.Performed)
            {
                if (!secondTouch)
                {
                    previousDistance = Vector2.Distance(
                        primaryTouch.ReadValue<Vector2>(),
                        secondaryTouch.ReadValue<Vector2>()
                    );
                    
                    Vector2 zoomScreen = (primaryTouch.ReadValue<Vector2>() + secondaryTouch.ReadValue<Vector2>()) * 0.5f;
                    zoomMiddlePoint = StaticFunctions.FromScreenPointToWorldPoint(zoomScreen);
                }
                
                secondTouch = true;
            }
            else if (secTouch.phase is InputActionPhase.Canceled or InputActionPhase.Waiting)
            {
                secondTouch = false;
            }
        }
        
        private void ZoomCamera()
        {
            if (secondTouch)
            {
                currentDistance = Vector2.Distance(
                    primaryTouch.ReadValue<Vector2>(), 
                    secondaryTouch.ReadValue<Vector2>()
                    );

                float deltaDistance = currentDistance - previousDistance;
                float newZoomScale = recomposer.ZoomScale - deltaDistance * Time.deltaTime * zoomSensitivity;
                newZoomScale = Mathf.Clamp(newZoomScale, zoomClamp.x, zoomClamp.y);
                
                recomposer.ZoomScale = Mathf.Lerp(
                    recomposer.ZoomScale, 
                    newZoomScale, 
                    smoothZoomSpeed * Time.deltaTime); 
                
                cameraTarget.position = Vector3.Lerp(cameraTarget.position, zoomMiddlePoint, zoomMoveSpeed);

                previousDistance = currentDistance;
            }
        }
    }
}