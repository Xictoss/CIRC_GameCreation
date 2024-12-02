using UnityEngine;

namespace CIRC.Core.Progression.Core.Data
{
    [CreateAssetMenu(fileName = "NewBadgeScriptable", menuName = "CIRC/Save/BadgeScriptable", order = 0)]
    public class BadgeData : SaveScriptable
    {
        public string badgeName;
        public Sprite displayImage;
    }
}