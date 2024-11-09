using UnityEngine;

namespace NomDuJeu.Core
{
    public static class StaticFunctions
    {
        public static Vector3 GetRandomPositionWithinBounds2D(BoxCollider2D boundsCollider, float positionZ)
        {
            return new Vector3(
                Random.Range(boundsCollider.bounds.min.x, boundsCollider.bounds.max.x),
                Random.Range(boundsCollider.bounds.min.y, boundsCollider.bounds.max.y),
                positionZ
            );
        }
    }
}
