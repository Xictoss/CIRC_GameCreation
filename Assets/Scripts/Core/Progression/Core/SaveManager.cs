using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
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
                
                MiniGameDataHolder[] miniGameDataHolders = Resources.LoadAll<MiniGameDataHolder>("Games");
                foreach (MiniGameDataHolder dataHolder in miniGameDataHolders)
                {
                    if (runtimeData.All(data => data.MiniGameId != dataHolder.miniGameName))
                    {
                        runtimeData.Add(new MiniGameData(dataHolder.miniGameName, false, dataHolder.badgeDisplay, dataHolder.gameSubject));
                    }
                }
            
                SaveData();
                Debug.LogWarning("Save file not found. Starting with empty data.");
            }
        }

        public void MarkMiniGameCompleted(MiniGameDataHolder data)
        {
            for (int i = 0; i < runtimeData.Count; i++)
            {
                if (runtimeData[i].MiniGameId == data.miniGameName)
                {
                    runtimeData[i] = new MiniGameData(data.miniGameName, true, data.badgeDisplay, data.gameSubject);
                    return;
                }
            }

            // If not found, add new entry
            runtimeData.Add(new MiniGameData(data.miniGameName, true, data.badgeDisplay, data.gameSubject));
        }

        public void MarkMiniGameUncompleted(MiniGameDataHolder data)
        {
            for (int i = 0; i < runtimeData.Count; i++)
            {
                if (runtimeData[i].MiniGameId == data.miniGameName)
                {
                    runtimeData[i] = new MiniGameData(data.miniGameName, false, data.badgeDisplay, data.gameSubject);
                    return;
                }
            }
            
            // If not found, add new entry
            runtimeData.Add(new MiniGameData(data.miniGameName, false, data.badgeDisplay, data.gameSubject));
        }
        
        public void MarkMiniGameStructCompleted(MiniGameData data)
        {
            for (int i = 0; i < runtimeData.Count; i++)
            {
                if (runtimeData[i].MiniGameId == data.MiniGameId)
                {
                    runtimeData[i] = new MiniGameData(data.MiniGameId, true, data.BadgeDisplay, data.GameSubject);
                    return;
                }
            }

            // If not found, add new entry
            runtimeData.Add(new MiniGameData(data.MiniGameId, true, data.BadgeDisplay, data.GameSubject));
        }

        public void MarkMiniGameStructUncompleted(MiniGameData data)
        {
            for (int i = 0; i < runtimeData.Count; i++)
            {
                if (runtimeData[i].MiniGameId == data.MiniGameId)
                {
                    runtimeData[i] = new MiniGameData(data.MiniGameId, false, data.BadgeDisplay, data.GameSubject);
                    return;
                }
            }
            
            // If not found, add new entry
            runtimeData.Add(new MiniGameData(data.MiniGameId, false, data.BadgeDisplay, data.GameSubject));
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