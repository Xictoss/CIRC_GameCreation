using UnityEngine;

namespace NomDuJeu.MiniGames.Core
{
    [CreateAssetMenu(fileName = "NewEntityData", menuName = "EntityScriptable", order = 0)]
    public class EntityData : ScriptableObject
    {
        public float Speed;
        public Sprite Sprite;
        public bool Good;
    }
}