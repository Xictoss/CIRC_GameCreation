using CIRC.Core.Progression.Core.Enums;
using NaughtyAttributes;
using UnityEngine;

namespace CIRC.Core.Progression.Core.Data
{
    [CreateAssetMenu(fileName = "NewMiniGameScriptable", menuName = "CIRC/Save/MiniGameScriptable", order = 0)]
    public class MiniGameData : SaveScriptable
    {
        public string gameName;
        public GameSubject subject;
        public BadgeData badge;
        
        [Button]
        public void GenerateGuid()
        {
            saveElement.SetNewGuid();
        }
        [Button]
        public void ResetName()
        {
            gameName = name;
        }
    }
}