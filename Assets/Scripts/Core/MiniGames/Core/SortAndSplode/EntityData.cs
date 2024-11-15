using UnityEngine;

namespace CIRC.Core.MiniGames.Core.SortAndSplode
{
    [CreateAssetMenu(fileName = "NewEntityData", menuName = "EntityScriptable", order = 0)]
    public class EntityData : ScriptableObject
    {
        public float Speed;
        public Sprite Sprite;
        public bool Good;
    }
}