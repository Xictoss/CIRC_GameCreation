using System.Collections;
using System.IO;
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
        
        public static IEnumerator TakeScreenshotAndShare(this bool hasScreen)
        {
            yield return new WaitForEndOfFrame();
            
            if (hasScreen)
            {
	            Texture2D ss = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
	            ss.ReadPixels(new Rect(0, 0, Screen.width, Screen.height ), 0, 0);
	            ss.Apply();

	            string filePath = Path.Combine(Application.temporaryCachePath, "shared img.png");
	            File.WriteAllBytes(filePath, ss.EncodeToPNG());

	            // To avoid memory leaks
	            // Destroy(ss);
                
                new NativeShare().AddFile(filePath)
		        .SetSubject("CIRC Game").SetText("Essaye ce nouveau jeu sur la prévention contre le cancer").SetUrl("https://github.com/Xictoss/CIRC_GameCreation")
		        .Share();

            }
            else
            {
                new NativeShare().SetSubject("CIRC Game")
                    .SetText("Essaye ce nouveau jeu sur la prévention contre le cancer").SetUrl("https://github.com/Xictoss/CIRC_GameCreation")
                    .Share();
            }
        }
    }
}