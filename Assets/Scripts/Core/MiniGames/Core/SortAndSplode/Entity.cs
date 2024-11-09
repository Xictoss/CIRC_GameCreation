using NomDuJeu.Core;
using NomDuJeu.Inputs.SortAndSplode;
using UnityEngine;

namespace NomDuJeu.MiniGames.Core.SortAndSplode
{
    public class Entity : MonoBehaviour
    {
        [field : SerializeField] public EntityData entityData { get; private set; }
        [SerializeField] private SpriteRenderer sr;
        
        public BoxCollider2D moveBounds;
        private Vector3 targetPosition;
        public bool isDragged;
        
        public void FirstFrame()
        {
            sr.sprite = entityData.sprite;
            SetNewTargetPosition();
        }

        public void Refresh()
        {
            if (isDragged)
            {
                transform.position = InputController.Instance.worldTouchPosition;
            }
            else
            {
                MoveEntity();
            }
        }

        private void SetNewTargetPosition()
        {
            targetPosition = StaticFunctions.GetRandomPositionWithinBounds2D(moveBounds, transform.position.z);
        }

        private void MoveEntity()
        {
            if (Mathf.Abs(targetPosition.magnitude - transform.position.magnitude) <= 0.1f) SetNewTargetPosition();
            
            Vector3 direction = (targetPosition - transform.position).normalized;
            transform.Translate(direction * (entityData.speed * Time.deltaTime));
        }
    }
}
