using UnityEngine;
using UnityEngine.SceneManagement;

namespace CIRC.Core
{
    public static class StaticFunctions
    {
        public static Vector2 GetRandomPositionWithinRectTransform(this RectTransform imageRectTransform)
        {
            float randomX = Random.Range(0f, 1f);
            float randomY = Random.Range(0f, 1f);
            
            float imageWidth = imageRectTransform.rect.width;
            float imageHeight = imageRectTransform.rect.height;

            Vector2 localPosition = new Vector2(randomX * imageWidth - imageWidth / 2, randomY * imageHeight - imageHeight / 2);
            return localPosition;
        }

        public static Vector3 FromScreenPointToWorldPoint(this Vector3 screenPosition)
        {
            if (Camera.main)
            {
                Vector3 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
                worldPosition = new Vector3(worldPosition.x, worldPosition.y, 0f);
                return worldPosition;
            }
            
            return Vector3.zero;
        }
        
        public static void LoadScene(this int sceneIndex)
        {
            //Debug.Log("Load Scene : " + sceneIndex);
            SceneManager.LoadScene(sceneIndex);
        }
        
        public static void LoadScene(this string sceneName)
        {
            //Debug.Log("Load Scene : " + sceneIndex);
            SceneManager.LoadScene(SceneManager.GetSceneByName(sceneName).buildIndex);
        }
    }
}