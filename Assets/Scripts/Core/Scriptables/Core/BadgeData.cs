using UnityEngine;

namespace CIRC.Core.Scriptables.Core
{
    [CreateAssetMenu(fileName = "NewBadgeScriptable", menuName = "CIRC/Save/BadgeScriptable", order = 0)]
    public class BadgeData : SaveScriptable
    {
        public string badgeName;
        public Sprite displayImage;
    }
}