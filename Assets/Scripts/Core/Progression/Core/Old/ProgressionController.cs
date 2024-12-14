using System.IO;
using UnityEngine;

namespace CIRC.Core.Progression.Core
{
    public static class ProgressionController
    {
        public static void SaveProgressData(SaveData saveData)
        {
            string json = JsonUtility.ToJson(saveData, true);

            string directoryPath = GetSavePathFromDevice();
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            string filePath = Path.Combine(directoryPath, "PlayerProgressionSave.json");
            File.WriteAllText(filePath, json);
        }

        public static SaveData LoadProgressData()
        {
            string jsonData = File.ReadAllText(Path.Combine(GetSavePathFromDevice(),"PlayerProgressionSave.json"));
            SaveData progressToLoad = JsonUtility.FromJson<SaveData>(jsonData);
            
            return progressToLoad;
        }

        public static void SaveProgressDataToPlayerPrefs(SaveData saveData)
        {
            string json = JsonUtility.ToJson(saveData, false);
            
            PlayerPrefs.SetString("PlayerProgressSave", json);
        }
        
        public static SaveData LoadProgressDataFromPlayerPrefs()
        {
            SaveData progressToLoad = new SaveData(Application.version);
            
            try
            {
                string json = PlayerPrefs.GetString("PlayerProgressSave", "Default");
                progressToLoad = JsonUtility.FromJson<SaveData>(json);
                progressToLoad.SaveVersion = Application.version;
            }
            catch
            {
                progressToLoad.SaveVersion = "0";
            }
            
            return progressToLoad;
        }
        
        private static string GetSavePathFromDevice()
        {
            #if UNITY_EDITOR
            return Application.persistentDataPath + "/StreamingAssets/Save";
            #elif UNITY_ANDROID
            return "jar:file://" + Application.persistentDataPath + "!/assets/";
            #elif UNITY_IOS
            return "file://" + Application.persistentDataPath + "/Raw/";
            #endif
        }
    }
}