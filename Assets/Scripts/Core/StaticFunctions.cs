using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CIRC.Core
{
    public static partial class StaticFunctions
    {
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