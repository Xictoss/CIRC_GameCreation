using System;
using DG.DemiEditor;
using UnityEditor;

namespace CIRC.Core.Progression.Core
{
    [System.Serializable]
    public struct SaveElement : IEquatable<SaveElement>
    {
        public string guidID;
        public bool isComplete;

        public SaveElement(string guidID)
        {
            this.guidID = guidID;
            isComplete = false;
        }
        
        public void SetNewGuid()
        {
            if (!guidID.IsNullOrEmpty()) return;
            guidID = GUID.Generate().ToString();
        }

        #region Equals Override

        public bool Equals(SaveElement other)
        {
            return guidID == other.guidID;
        }

        public override bool Equals(object obj)
        {
            return obj is SaveElement other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(guidID);
        }

        #endregion
    }
}