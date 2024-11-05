using System;

namespace NomDuJeu.Core.Progression
{
    [System.Serializable]
    public struct SaveElement : IEquatable<SaveElement>
    {
        public string keyID;
        public bool isUnlocked;

        public bool Equals(SaveElement other)
        {
            return keyID == other.keyID;
        }

        public override bool Equals(object obj)
        {
            return obj is SaveElement other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(keyID);
        }
    }
}