using CIRC.Inputs;
using UnityEngine;

namespace CIRC.Player
{
    public class PlayerCamera : MonoBehaviour
    {
        private static InputController InputController => InputController.Instance;

        [Header("References")]
        [SerializeField] private Transform cameraTarget;
        
        [Header("Drag Parameters")] 
        [SerializeField] private Bounds cameraMoveRange;
        [SerializeField] private float smoothClampSpeed = 15f;
        private Vector3 targetSwipePos;
 
        private void Update()
        {
            MoveCamera();
            ZoomCamera();

            ClampCamera();
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
            Vector2 delta = InputController.PlayerInputActions.TouchScreen.Swipe.ReadValue<Vector2>();
            Vector2 centerScreen = new Vector2(Screen.width * .5f, Screen.height * .5f);

            Vector3 centerPos = StaticFunctions.FromScreenPointToWorldPoint(centerScreen);
            Vector3 offsetPos = StaticFunctions.FromScreenPointToWorldPoint(centerScreen + delta);

            Vector3 worldDelta = offsetPos - centerPos;
            worldDelta.y = 0;

            cameraTarget.Translate(-worldDelta);
        }
        
        private void ZoomCamera()
        {
            
        }
    }
}