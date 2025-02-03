using System;
using UnityEngine;

namespace CIRC.Progression
{
    [CreateAssetMenu(menuName = "CIRC/Progression/MiniGameDataHolder", fileName = "MiniGameDataHolder")]
    public class MiniGameDataHolder : ScriptableObject
    {
        public string miniGameName;
        public GameSubject gameSubject;
        public BadgeData badgeDisplay;
        
        public string GUID;

        private void Awake()
        {
            if (string.IsNullOrEmpty(GUID))
            {
                GUID = Guid.NewGuid().ToString();
                Debug.Log($"New guid : {GUID} for {miniGameName}");
            }
        }
    }
}