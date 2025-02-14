using CIRC.Controllers;
using UnityEngine;

namespace CIRC.CameraScripts
{
    public class CameraController
    {
        public static CameraController Global => GameController.CameraController;
        public CameraAttributes CameraAttributes { get; private set; }
        public CameraState CameraState { get; private set; }

        public void SetCameraState(Vector3 pos, float zoom)
        {
            CameraAttributes = new CameraAttributes()
            {
                cameraPosition = pos,
                cameraZoom = zoom,
            };
        }
    }
}