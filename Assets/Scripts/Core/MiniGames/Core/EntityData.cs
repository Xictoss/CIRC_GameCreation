using UnityEngine;

namespace NomDuJeu.MiniGames.Core
{
    [CreateAssetMenu(fileName = "NewEntityData", menuName = "EntityScriptable", order = 0)]
    public class EntityData : ScriptableObject
    {
        public string ID;
        
        public float Speed;
        public float NewTargetRate;
        public Sprite Sprite;
        public bool Good;
    }
}