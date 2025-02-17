using System;
using DevLocker.Utils;
using UnityEngine;

namespace CIRC.Progression
{
    [CreateAssetMenu(menuName = "CIRC/Progression/MiniGameDataHolder", fileName = "MiniGameDataHolder")]
    public class MiniGameDataHolder : ScriptableObject
    {
        public string miniGameName;
        public string miniGameDesc;
        public string miniGameTitle;
        
        public SceneReference scene;
        
        public GameSubject gameSubject;
        public BadgeData badgeDisplay;
        
        public string GUID;
    }
}