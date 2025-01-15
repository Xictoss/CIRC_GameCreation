using System;
using CIRC.Core.Progression.Core.Core.Progression.Core;
using NaughtyAttributes;
using UnityEngine;

namespace CIRC.Core.Progression.Core
{
    [CreateAssetMenu(menuName = "CIRC/Progression/MiniGameDataHolder", fileName = "MiniGameDataHolder")]
    public class MiniGameDataHolder : ScriptableObject
    {
        public string miniGameName;
        public GameSubject gameSubject;
        public BadgeData badgeDisplay;
        [HideInInspector]
        public string GUID;

        private void Awake()
        {
            if (string.IsNullOrEmpty(GUID))
            {
                GUID = Guid.NewGuid().ToString();
                Debug.Log($"New guid : {GUID} for {miniGameName}");
            }
        }
        
        [Button]
        private void OnValidate()
        {
            Awake();
        }
    }
}