using CIRC.Inputs;
using UnityEngine;

namespace CIRC.Player
{
    public class PlayerCamera : MonoBehaviour
    {
        [SerializeField] private Transform cam;
        [SerializeField] private float speed = 5;

        private void OnEnable()
        {
            InputController.Instance.OnSwipeInput += MoveCamera;
        }
        
        private void OnDisable()
        {
            InputController.Instance.OnSwipeInput -= MoveCamera;
        }

        private void MoveCamera(Vector2 swipe)
        {
            Vector3 dir = (Vector3) swipe;
            cam.Translate(dir * speed);
        }
    }
}