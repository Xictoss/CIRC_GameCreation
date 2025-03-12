using UnityEngine;

namespace CIRC.MenuSystem
{
    [System.Serializable]
    public struct MenuMoveLink
    {
        public Transform menuTransform;
        public Transform targetTransformOn;
        public Transform targetTransformOff;
        public float moveDuration;
    }
}