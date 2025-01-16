using UnityEngine;

namespace CIRC
{
    public partial class StaticFunctions
    {
        public static Vector2 GetRandomPositionWithinRectTransform(this RectTransform imageRectTransform)
        {
            float randomX = Random.value;
            float randomY = Random.value;
            
            float imageWidth = imageRectTransform.rect.width;
            float imageHeight = imageRectTransform.rect.height;

            Vector2 localPosition = new Vector2(randomX * imageWidth - imageWidth / 2, randomY * imageHeight - imageHeight / 2);
            return localPosition;
        }

        public static Vector3 FromScreenPointToWorldPoint(this Vector3 screenPosition)
        {
            if (UnityEngine.Camera.main)
            {
                Vector3 worldPosition = UnityEngine.Camera.main.ScreenToWorldPoint(screenPosition);
                worldPosition = new Vector3(worldPosition.x, worldPosition.y, 0f);
                return worldPosition;
            }
            
            return Vector3.zero;
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