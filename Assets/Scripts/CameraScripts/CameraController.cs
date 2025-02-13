using CIRC.Controllers;
using UnityEngine;

namespace CIRC.CameraScripts
{
    public class CameraController
    {
        public static CameraController Global => GameController.CameraController;
        public CameraState CameraState { get; private set; }

        public void SetCameraState(Vector3 pos, float zoom)
        {
            CameraState = new CameraState()
            {
                cameraPosition = pos,
                cameraZoom = zoom,
            };
        }
    }
}