using System;
using UnityEngine;

namespace CIRC.Progression
{
    [CreateAssetMenu(menuName = "CIRC/Progression/MiniGameDataHolder", fileName = "MiniGameDataHolder")]
    public class MiniGameDataHolder : ScriptableObject
    {
        public string miniGameName;
        public string miniGameDesc;
        public string miniGameTitle;
        public GameSubject gameSubject;
        public BadgeData badgeDisplay;
        
        public string GUID;
    }
}