using System.Collections.Generic;
using UnityEngine;

namespace NomDuJeu.Core.Progression
{
    [System.Serializable]
    public struct SaveData
    {
        [SerializeField]
        private List<SaveElement> playerProgression;
        public int version;

        public SaveData(int version)
        {
            this.version = version;
            playerProgression = new List<SaveElement>();
        }

        public void Write(SaveElement saveElement)
        {
            int index = playerProgression.IndexOf(saveElement);

            if (index == -1)
            {
                playerProgression.Add(saveElement);
            }
            else
            {
                playerProgression[index] = saveElement;
            }
        }
    }
}