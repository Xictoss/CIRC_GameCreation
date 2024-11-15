using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;

namespace CIRC.Core.Progression.Core
{
    [System.Serializable]
    public struct SaveData
    {
        public string SaveVersion;
        [field : SerializeField] public List<SaveElement> PlayerProgression { get; private set; }

        public SaveData(string version)
        {
            SaveVersion = version;
            PlayerProgression = new List<SaveElement>();
        }

        public void Write(SaveElement saveElement)
        {
            int index = PlayerProgression.IndexOf(saveElement);

            if (index == -1)
            {
                PlayerProgression.Add(saveElement);
            }
            else
            {
                PlayerProgression[index] = saveElement;
            }
        }

        public void SetPlayerCompleted(string guidID)
        {
            SaveElement element = PlayerProgression.Find(e => e.GuidID == guidID);
            SetPlayerCompleted(element);
        }

        public void SetPlayerCompleted(SaveElement element)
        {
            element.IsComplete = true;
            Write(element);
        }
    }
}