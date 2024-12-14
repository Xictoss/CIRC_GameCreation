using CIRC.Core.Progression.Core.Data;
using CIRC.Core.Progression.Core.Enums;
using UnityEngine;

namespace CIRC.Core.Progression.Core.Core.Progression.Core
{
    [CreateAssetMenu(menuName = "CIRC/MiniGameDataHolder", fileName = "MiniGameDataHolder")]
    public class MiniGameDataHolder : ScriptableObject
    {
        public string miniGameName;
        public GameSubject gameSubject;
        public BadgeData badgeDisplay;
    }
}