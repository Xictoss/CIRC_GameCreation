using UnityEngine;

namespace CIRC.Core.Scriptables.Core
{
    [CreateAssetMenu(fileName = "NewBadgeScriptable", menuName = "BadgeScriptable", order = 0)]
    public class BadgeScriptable : SaveScriptable
    {
        public string BadgeName;
        public Sprite BadgeDisplayImage;
    }
}