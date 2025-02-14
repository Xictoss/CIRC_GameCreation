using UnityEngine;

namespace CIRC.Animals
{
    public class LookAtCamera : MonoBehaviour
    {
        [SerializeField] private bool invert;
        private Camera cam;
        
        private void Awake()
        {
            cam = Camera.main;
        }

        private void Update()
        {
            if (invert)
            {
                Vector3 oppositeDirection = transform.position - cam.transform.position;
                transform.LookAt(transform.position + oppositeDirection);
            }
            else
            {
                transform.LookAt(cam.transform);
            }
        }
    }
}