using SaveSystem.Core;
using UnityEngine;

namespace CIRC.Core.Controllers
{
    public class PlayerPrefsSaveManager : ISaveManager
    {
        public bool Load<T, TS>(out T save, TS settings)
            where T : ISaveFile
            where TS : ISaveFileSettings<T>
        {

            if (settings is GameSaveSettings saveSettings)
            {
                if (PlayerPrefs.HasKey(saveSettings.prefName))
                {
                    string json = PlayerPrefs.GetString(saveSettings.prefName);
                    save = JsonUtility.FromJson<T>(json);
                    return save != null;
                }
            }

            save = default;
            return false;
        }

        public bool Save<T, TS>(T save, TS settings)
            where T : ISaveFile
            where TS : ISaveFileSettings<T>
        {
            if (settings is GameSaveSettings saveSettings)
            {
                string json = JsonUtility.ToJson(save);
                PlayerPrefs.SetString(saveSettings.prefName, json);
            }

            return true;
        }
    }
}