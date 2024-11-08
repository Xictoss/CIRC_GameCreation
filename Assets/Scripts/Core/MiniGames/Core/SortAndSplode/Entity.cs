using NomDuJeu.Core;
using NomDuJeu.Inputs.SortAndSplode;
using UnityEngine;

namespace NomDuJeu.MiniGames.Core.SortAndSplode
{
    public class Entity : MonoBehaviour
    {
        [field : SerializeField] public EntityData entityData { get; private set; }
        [SerializeField] private SpriteRenderer sr;
        
        public BoxCollider2D boundsCollider;
        private Vector3 targetPosition;

        public bool isDragged;
        
        public void FirstFrame()
        {
            sr.sprite = entityData.Sprite;
            SetNewTargetPosition();
        }

        public void Refresh()
        {
            if (!isDragged)
            {
                MoveEntity();
            }
            else
            {
                FollowTouchPosition();
            }
        }

        private void FollowTouchPosition()
        {
            transform.position = InputController.Instance.worldTouchPosition;
        }

        private void SetNewTargetPosition()
        {
            targetPosition = StaticFunctions.GetRandomPositionWithinBounds2D(boundsCollider, transform.position.z);
        }

        private void MoveEntity()
        {
            if (Mathf.Abs(targetPosition.magnitude - transform.position.magnitude) < 0.1f) SetNewTargetPosition();
            
            Vector3 direction = (targetPosition - transform.position).normalized;
            transform.Translate(direction * (entityData.Speed * Time.deltaTime));
        }
    }
}
