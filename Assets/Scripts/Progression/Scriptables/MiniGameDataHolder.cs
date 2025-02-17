using DevLocker.Utils;
using UnityEngine;

namespace CIRC.Progression
{
    [CreateAssetMenu(menuName = "CIRC/Progression/MiniGameDataHolder", fileName = "MiniGameDataHolder")]
    public class MiniGameDataHolder : ScriptableObject
    {
        public string miniGameName;
        [Space(20)]
        public string miniGameDesc;
        public string miniGameTitle;

        [Space(20)] 
        public string endDesc;
        public string endExplication;
        
        [Space(20)]
        public SceneReference scene;
        
        [Space(20)]
        public GameSubject gameSubject;
        public BadgeData badgeDisplay;
        
        public string GUID;
    }
}