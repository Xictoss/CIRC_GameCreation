using NaughtyAttributes;
using UnityEngine;

namespace CIRC.Core.Progression.Core.Data
{
    [CreateAssetMenu(fileName = "NewBadgeScriptable", menuName = "CIRC/Save/BadgeScriptable", order = 0)]
    public class BadgeData : ScriptableObject
    {
        public string badgeName;
        public Sprite displayImage;
        public string description;
        
#if UNITY_EDITOR
        [Button]
        public void ResetName()
        {
            badgeName = name;
        }
#endif
    }
}