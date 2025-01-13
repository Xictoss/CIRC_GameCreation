using CIRC.Core.Progression.Core.Core.Progression.Core;
using UnityEngine;

namespace CIRC.Core.Progression.Core
{
    [CreateAssetMenu(menuName = "CIRC/Progression/MiniGameDataHolder", fileName = "MiniGameDataHolder")]
    public class MiniGameDataHolder : ScriptableObject
    {
        public string miniGameName;
        public GameSubject gameSubject;
        public BadgeData badgeDisplay;
    }
}