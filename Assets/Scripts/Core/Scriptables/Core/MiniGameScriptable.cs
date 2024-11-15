using UnityEngine;

namespace CIRC.Core.Scriptables.Core
{
    [CreateAssetMenu(fileName = "NewMiniGameScriptable", menuName = "MiniGameScriptable", order = 0)]
    public class MiniGameScriptable : SaveScriptable
    {
        public string MiniGameName;
        public BadgeScriptable MiniGameBadge;
    }
}