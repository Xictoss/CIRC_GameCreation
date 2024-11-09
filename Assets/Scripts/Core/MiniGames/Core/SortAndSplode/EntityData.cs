using UnityEngine;

namespace NomDuJeu.MiniGames.Core
{
    [CreateAssetMenu(fileName = "NewEntityData", menuName = "EntityScriptable", order = 0)]
    public class EntityData : ScriptableObject
    {
        public float speed;
        public Sprite sprite;
        public bool good;
    }
}