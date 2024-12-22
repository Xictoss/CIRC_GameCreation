using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using CIRC.Core.Progression.Core.Core.Progression.Core;
using LTX.Singletons;
using UnityEngine;

namespace CIRC.Core.Progression.Core
{
    public class SaveManager : MonoSingleton<SaveManager>
    {
        [field: SerializeField] public List<MiniGameData> runtimeData { get; private set; } = new List<MiniGameData>();
        private string saveFilePath => Path.Combine(Application.persistentDataPath, "saveData.dat");
        private readonly byte encryptionKey = 0x2B;

        protected override void Awake()
        {
            base.Awake();
            
            DontDestroyOnLoad(this);
        }

        public void SaveData()
        {
            try
            {
                using (FileStream fs = new FileStream(saveFilePath, FileMode.Create))
                {
                    BinaryFormatter formatter = new BinaryFormatter();

                    using (MemoryStream ms = new MemoryStream())
                    {
                        // Serialize the data to memory
                        formatter.Serialize(ms, runtimeData);

                        // Encrypt the data and write to file
                        byte[] encryptedData = Encrypt(ms.ToArray());
                        fs.Write(encryptedData, 0, encryptedData.Length);
                    }
                }

                Debug.Log("Data saved successfully.");
            }
            catch (Exception ex)
            {
                Debug.LogError($"Failed to save data: {ex.Message}");
            }
        }

        public void LoadData()
        {
            if (File.Exists(saveFilePath))
            {
                try
                {
                    using (FileStream fs = new FileStream(saveFilePath, FileMode.Open))
                    {
                        byte[] encryptedData = new byte[fs.Length];
                        fs.Read(encryptedData, 0, encryptedData.Length);

                        // Decrypt the data
                        byte[] decryptedData = Decrypt(encryptedData);

                        using (MemoryStream ms = new MemoryStream(decryptedData))
                        {
                            BinaryFormatter formatter = new BinaryFormatter();
                            runtimeData = (List<MiniGameData>)formatter.Deserialize(ms);
                        }
                    }

                    Debug.Log("Data loaded successfully.");
                }
                catch (Exception ex)
                {
                    Debug.LogError($"Failed to load data: {ex.Message}");
                }
            }
            else
            {
                runtimeData = new List<MiniGameData>();
                Debug.LogWarning("Save file not found. Starting with empty data.");
            }
        }

        public void MarkMiniGameCompleted(string miniGameId, BadgeData badgeDisplay, GameSubject subject)
        {
            for (int i = 0; i < runtimeData.Count; i++)
            {
                if (runtimeData[i].MiniGameId == miniGameId)
                {
                    runtimeData[i] = new MiniGameData(miniGameId, true, badgeDisplay, subject);
                    return;
                }
            }

            // If not found, add new entry
            runtimeData.Add(new MiniGameData(miniGameId, true, badgeDisplay, subject));
        }

        public void MarkMiniGameUncompleted(string miniGameId, BadgeData badgeDisplay, GameSubject subject)
        {
            for (int i = 0; i < runtimeData.Count; i++)
            {
                if (runtimeData[i].MiniGameId == miniGameId)
                {
                    runtimeData[i] = new MiniGameData(miniGameId, false, badgeDisplay, subject);
                    return;
                }
            }
        }

        public bool IsMiniGameCompleted(string miniGameId)
        {
            foreach (var data in runtimeData)
            {
                if (data.MiniGameId == miniGameId)
                {
                    return data.IsCompleted;
                }
            }
            return false;
        }

        // Get all saved mini-game data (for debugging or displaying progress)
        public List<MiniGameData> GetAllMiniGameData()
        {
            return runtimeData;
        }

        private byte[] Encrypt(byte[] data)
        {
            byte[] encryptedData = new byte[data.Length];
            for (int i = 0; i < data.Length; i++)
            {
                encryptedData[i] = (byte)(data[i] ^ encryptionKey);
            }
            return encryptedData;
        }

        private byte[] Decrypt(byte[] data)
        {
            return Encrypt(data); // XOR is symmetric
        }

        public void PrintAllData()
        {
            Debug.Log("MiniGame Data:");
            foreach (var data in runtimeData)
            {
                Debug.Log($"MiniGame ID: {data.MiniGameId}, Completed: {data.IsCompleted}");
            }
        }
    }
}