using UnityEngine;

namespace NomDuJeu.MiniGames.Core
{
    public class Entity : MonoBehaviour
    {
        [SerializeField] private EntityData entityData;
        [SerializeField] private SpriteRenderer sr;
        
        public BoxCollider2D moveBounds;
        private Vector3 targetPosition;
        private float moveTimer = 0f;

        public void LoadScene()
        {
            sr = gameObject.GetComponent<SpriteRenderer>();
            sr.sprite = entityData.Sprite;
        }
        
        public bool FirstFrame()
        {
            SetNewTargetPosition();
            return true;
        }

        public bool Refresh()
        {
            MoveEntity();
            
            return true;
        }

        private void SetNewTargetPosition()
        {
            targetPosition = new Vector3(
                Random.Range(moveBounds.bounds.min.x, moveBounds.bounds.max.x),
                Random.Range(moveBounds.bounds.min.y, moveBounds.bounds.max.y),
                transform.position.z
            );
        }

        private void MoveEntity()
        {
            if (Mathf.Abs(targetPosition.magnitude - transform.position.magnitude) < 0.1f) SetNewTargetPosition();
            
            Vector3 direction = (targetPosition - transform.position).normalized;
            transform.Translate(direction * (entityData.Speed * Time.deltaTime));
        }
    }
}
