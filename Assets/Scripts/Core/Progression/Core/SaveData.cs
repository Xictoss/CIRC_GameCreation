using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;

namespace NomDuJeu.Progression.Core
{
    [System.Serializable]
    public struct SaveData
    {
        public string saveVersion;
        [field : SerializeField] public List<SaveElement> PlayerProgression { get; private set; }

        public SaveData(string version)
        {
            saveVersion = version;
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
            SaveElement element = PlayerProgression.Find(e => e.guidID == guidID);
            SetPlayerCompleted(element);
        }

        public void SetPlayerCompleted(SaveElement element)
        {
            element.isComplete = true;
            Write(element);
        }
    }
}