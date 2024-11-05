using System;
using System.IO;
using UnityEngine;

namespace NomDuJeu.Core.Progression
{
    public class ProgressionController : MonoBehaviour
    {
        private SaveData temporaryProgress;
        
        /*
        private void ShowProgression()
        {
            foreach (SaveElement se in temporaryProgress.saveElements)
            {
                Debug.Log($"Key: {se.keyID}, Value: {se.isUnlocked}");
            }
        }
        */

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                SaveProgress();
            }
            
            if (Input.GetKeyDown(KeyCode.R))
            {
                SaveElement saveElement = new SaveElement
                {
                    keyID = Guid.NewGuid().ToString(),
                    isUnlocked = false
                };
                
                temporaryProgress.Write(saveElement);
            }
        }
        
        public void SaveProgress()
        {
            string json = JsonUtility.ToJson(temporaryProgress, true);

            string directoryPath = Path.Combine(Application.dataPath, "StreamingAssets");
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            string filePath = Path.Combine(directoryPath, "PlayerProgressionSave.json");
            File.WriteAllText(filePath, json);
        }
    }
}