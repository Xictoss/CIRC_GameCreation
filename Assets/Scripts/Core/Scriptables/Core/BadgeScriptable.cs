using UnityEngine;

namespace NomDuJeu.Scriptables.Core
{
    [CreateAssetMenu(fileName = "NewBadgeScriptable", menuName = "BadgeScriptable", order = 0)]
    public class BadgeScriptable : SaveScriptable
    {
        public string badgeName;
        public Sprite badgeDisplayImage;
    }
}