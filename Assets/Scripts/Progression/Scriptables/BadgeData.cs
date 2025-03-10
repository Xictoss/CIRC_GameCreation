using UnityEngine;

namespace CIRC.Progression
{
    [CreateAssetMenu(menuName = "CIRC/Progression/BadgeData", fileName = "BadgeData")]
    public class BadgeData : ScriptableObject
    {
        public Sprite displayImage;
        public GameSubject subject;

        public string badgeName;
        public string badgeDesc;
    }
}