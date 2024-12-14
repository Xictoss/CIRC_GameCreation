using CIRC.Core.Progression.Core.Enums;
using NaughtyAttributes;
using UnityEditor;
using UnityEngine;

namespace CIRC.Core.Progression.Core.Data
{
    [CreateAssetMenu(fileName = "NewMiniGameScriptable", menuName = "CIRC/Save/MiniGameScriptable", order = 0)]
    public class MiniGameDataOLD : SaveScriptable
    {
        [field : SerializeField] public string GameName { get; private set; }
        [field : SerializeField] public GameSubject Subject { get; private set; }
        [field : SerializeField] public BadgeData Badge { get; private set; }

        public void SetName(string newName) => GameName = newName;
        public void SetSubject(GameSubject sub) => Subject = sub;
        public void SetBadge(BadgeData badge) => Badge = badge;
        
#if UNITY_EDITOR
        [Button]
        public void SetGuid()
        {
            if (string.IsNullOrEmpty(SaveElement.GuidID)) return;
            SaveElement.GuidID = GUID.Generate().ToString();
        }
        [Button]
        public void ResetName()
        {
            GameName = name;
        }
#endif
    }
}