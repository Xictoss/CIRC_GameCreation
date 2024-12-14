using System;

namespace CIRC.Core.Progression.Core
{
    [System.Serializable]
    public struct SaveElement : IEquatable<SaveElement>
    {
        public string GuidID;
        public bool IsComplete;

        public SaveElement(string guidID)
        {
            this.GuidID = guidID;
            IsComplete = false;
        }

        #region Equals Override

        public bool Equals(SaveElement other)
        {
            return GuidID == other.GuidID;
        }

        public override bool Equals(object obj)
        {
            return obj is SaveElement other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(GuidID);
        }

        #endregion
    }
}