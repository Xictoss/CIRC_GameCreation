using UnityEngine;

namespace CIRC.Animals
{
    public class LookAtCamera : MonoBehaviour
    {
        private Camera cam;
        
        private void Awake()
        {
            cam = Camera.main;
        }

        private void Update()
        {
            transform.LookAt(cam.transform);
        }
    }
}