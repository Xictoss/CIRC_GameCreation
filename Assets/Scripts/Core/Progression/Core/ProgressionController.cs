using UnityEngine;

namespace NomDuJeu.Progression.Core
{
    public static class ProgressionController
    {
        /*public static void SaveProgressData(SaveData saveData)
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
        }*/

        public static void SaveProgressDataToPlayerPrefs(SaveData saveData)
        {
            string json = JsonUtility.ToJson(saveData, true);
            
            PlayerPrefs.SetString("PlayerProgressSave", json);
        }
        
        public static SaveData LoadProgressDataFromPlayerPrefs()
        {
            SaveData progressToLoad = new SaveData("0");
            
            try
            {
                Debug.Log("Loaded Player Progression");
                
                string json = PlayerPrefs.GetString("PlayerProgressSave", "Default");
                progressToLoad = JsonUtility.FromJson<SaveData>(json);
            }
            catch
            {
                Debug.Log("Loaded Default Save");
            }
            
            return progressToLoad;
        }
        
        private static string GetSavePathFromDevice()
        {
            #if UNITY_EDITOR
            return "file://" + Application.persistentDataPath + "/StreamingAssets/";
            #elif UNITY_ANDROID
            return "jar:file://" + Application.persistentDataPath + "!/assets/";
            #elif UNITY_IOS
            return "file://" + Application.persistentDataPath + "/Raw/";
            #endif
        }
    }
}