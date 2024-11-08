using System.IO;
using UnityEngine;

namespace NomDuJeu.Progression.Core
{
    public static class ProgressionController
    {
        public static void SaveProgressData(SaveData saveData)
        {
            string json = JsonUtility.ToJson(saveData, true);

            string directoryPath = StreamingAssetPathForReal();
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            string filePath = Path.Combine(directoryPath, "PlayerProgressionSave.json");
            File.WriteAllText(filePath, json);
        }

        public static SaveData LoadProgressData()
        {
            string jsonData = File.ReadAllText(Path.Combine(StreamingAssetPathForReal(),"PlayerProgressionSave.json"));
            SaveData progressToLoad = JsonUtility.FromJson<SaveData>(jsonData);
            
            return progressToLoad;
        }

        public static void SaveProgressDataToPlayerPrefs(SaveData saveData)
        {
            string json = JsonUtility.ToJson(saveData, true);
            PlayerPrefs.SetString("PlayerProgressSave", json);
        }
        
        public static SaveData LoadProgressDataFromPlayerPrefs()
        {
            string json = PlayerPrefs.GetString("PlayerProgressSave");
            
            SaveData progressToLoad = JsonUtility.FromJson<SaveData>(json);
            return progressToLoad;
        }
        
        private static string StreamingAssetPathForReal()
        {
            #if UNITY_EDITOR
            return "file://" + Application.dataPath + "/StreamingAssets/";
            #elif UNITY_ANDROID
            return "jar:file://" + Application.dataPath + "!/assets/";
            #elif UNITY_IOS
            return "file://" + Application.dataPath + "/Raw/";
            #endif
        }
    }
}