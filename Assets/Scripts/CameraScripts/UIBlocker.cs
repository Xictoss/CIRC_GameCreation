using System.Collections.Generic;
using CIRC.Inputs;
using LTX.Singletons;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace CIRC.CameraScripts
{
    public class UIBlocker : MonoSingleton<UIBlocker>
    {
        public GraphicRaycaster raycaster;
        public EventSystem eventSystem;

        public bool IsPointerOverUI()
        {
            PointerEventData eventData = new PointerEventData(eventSystem)
            {
                position = InputController.Instance.PlayerInputActions.TouchScreen.TouchPosition.ReadValue<Vector2>()
            };
            
            List<RaycastResult> results = new List<RaycastResult>();
            raycaster.Raycast(eventData, results);
            
            return results.Count > 0; // Returns true if UI elements are detected
        }
    }
}