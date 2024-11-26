using UnityEngine;

namespace CIRC.Core.Scriptables.Core
{
    [CreateAssetMenu(fileName = "NewMiniGameScriptable", menuName = "CIRC/Save/MiniGameScriptable", order = 0)]
    public class MiniGameData : SaveScriptable
    {
        public string MiniGameName;
        public BadgeData MiniGameBadge;
    }
}