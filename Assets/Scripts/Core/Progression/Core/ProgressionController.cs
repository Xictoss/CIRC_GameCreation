using System.IO;
using UnityEngine;

namespace NomDuJeu.Progression.Core
{
    public static class ProgressionController
    {
        public static void SaveProgressData(SaveData saveData)
        {
            string json = JsonUtility.ToJson(saveData, true);

            string directoryPath = Path.Combine(Application.dataPath, "StreamingAssets");
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            string filePath = Path.Combine(directoryPath, "PlayerProgressionSave.json");
            File.WriteAllText(filePath, json);
        }

        public static SaveData LoadProgressData()
        {
            string jsonData = File.ReadAllText(Application.dataPath + "/StreamingAssets/PlayerProgressionSave.json");
            SaveData progressToLoad = JsonUtility.FromJson<SaveData>(jsonData);
            
            return progressToLoad;
        }
    }
}