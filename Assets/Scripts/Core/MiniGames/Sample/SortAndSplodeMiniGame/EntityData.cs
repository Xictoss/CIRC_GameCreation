using UnityEngine;

namespace CIRC.Core.MiniGames.Sample.SortAndSplodeMiniGame
{
    [CreateAssetMenu(fileName = "NewEntityData", menuName = "CIRC/SortAndSplode/EntityScriptable", order = 0)]
    public class EntityData : ScriptableObject
    {
        public float Speed;
        public Sprite Sprite;
        public bool Good;
    }
}