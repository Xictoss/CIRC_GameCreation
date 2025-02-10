using UnityEngine;

namespace CIRC
{
    public partial class StaticFunctions
    {
        private static Camera cam;

        private static Camera Cam
        {
            get
            {
                if (cam == null)
                {
                    cam = Camera.main;
                }

                return cam;
            }
        }
        
        public static Vector2 GetRandomPositionWithinRectTransform(this RectTransform imageRectTransform)
        {
            float randomX = Random.value;
            float randomY = Random.value;
            
            float imageWidth = imageRectTransform.rect.width;
            float imageHeight = imageRectTransform.rect.height;

            Vector2 localPosition = new Vector2(randomX * imageWidth - imageWidth / 2, randomY * imageHeight - imageHeight / 2);
            return localPosition;
        }

        public static Vector3 FromScreenPointToWorldPoint(Vector3 screenPosition)
        {
            Ray ray = Cam.ScreenPointToRay(screenPosition);
            /*
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                return hit.point;
            }
            */

            Plane defaultPlane = GetDefaultPlane();
            if (defaultPlane.Raycast(ray, out float enter))
            {
                return ray.GetPoint(enter);
            }
            
            return Vector3.zero;
        }

        private static Plane GetDefaultPlane()
        {
            return new Plane(Vector3.up, Vector3.zero);
        }
        
        public static Bounds RectTransformToScreenSpace(this RectTransform rectTransform)
        {
            rectTransform.GetWorldCorners(corners);

            Vector3 position = (corners[0] + corners[2]) / 2;
            Vector3 size = corners[2] - corners[0];

            return new Bounds(position, size);
        }

        private static readonly Vector3[] corners = new Vector3[4];
        public static Bounds RectTransformToWorldBounds(this RectTransform rectTransform)
        {
            rectTransform.GetWorldCorners(corners);
            return GeometryUtility.CalculateBounds(corners, Matrix4x4.identity);
        }
    }
}