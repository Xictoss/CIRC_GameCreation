using CIRC.CameraScripts;
using UnityEditor;
using UnityEditor.IMGUI.Controls;
using UnityEngine;

namespace CIRC.Editor
{
    [CustomEditor(typeof(PlayerCamera))]
    public class PlayerCameraEditor : UnityEditor.Editor
    {
        private static BoxBoundsHandle boxBound = new BoxBoundsHandle();

        [DrawGizmo(GizmoType.Selected, typeof(PlayerCamera))]
        private static void DrawSceneGizmos(Component component, GizmoType gizmoType)
        {
            return;
            
            SerializedObject playerCamera = new SerializedObject(component);
            SerializedProperty boundsProperty = playerCamera.FindProperty("cameraMoveRange");
            
            boxBound.center = boundsProperty.boundsValue.center;
            boxBound.size = boundsProperty.boundsValue.size;
            
            EditorGUI.BeginChangeCheck();
            boxBound.DrawHandle();
            
            if (EditorGUI.EndChangeCheck())
            {
                Bounds bound = new Bounds(boxBound.center, boxBound.size);
                boundsProperty.boundsValue = bound;

                playerCamera.ApplyModifiedProperties();
            }
        }

        private void OnSceneGUI()
        {
            SerializedObject playerCamera = new SerializedObject(target);
            SerializedProperty boundsProperty = playerCamera.FindProperty("cameraMoveRange");
            
            boxBound.center = boundsProperty.boundsValue.center;
            boxBound.size = boundsProperty.boundsValue.size;
            
            EditorGUI.BeginChangeCheck();
            boxBound.DrawHandle();
            
            if (EditorGUI.EndChangeCheck())
            {
                Bounds bound = new Bounds(boxBound.center, boxBound.size);
                boundsProperty.boundsValue = bound;

                playerCamera.ApplyModifiedProperties();
            }
        }
    }
}