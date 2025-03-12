using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace CIRC.MiniGames.Sample
{
    public class Entity : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
    {
        [Header("Entity Data")]
        [field : SerializeField] public EntityData EntityData { get; private set; }
        
        [Header("Move Data")]
        internal RectTransform MoveArea;
        internal EntityManager manager;
        private bool IsDragged;
        private Vector2 targetPosition;
        
        [Header("References")]
        [field : SerializeField] public RectTransform RectTransform { get; private set; }
        [SerializeField] private Image _image;
        
        public void FirstFrame()
        {
            _image.sprite = EntityData.Sprite;
            SetNewTargetPosition();
        }
        
        public void Refresh()
        {
            if (!IsDragged)
            {
                MoveEntity();
            }
        }

        private void SetNewTargetPosition()
        {
            targetPosition = MoveArea.GetRandomPositionWithinRectTransform();
        }

        private void MoveEntity()
        {
            if ((targetPosition - RectTransform.anchoredPosition).sqrMagnitude <= 10f)
            {
                SetNewTargetPosition();
            }
            
            Vector2 direction = (targetPosition - RectTransform.anchoredPosition).normalized;
            RectTransform.anchoredPosition += direction * (EntityData.Speed * Time.deltaTime);
        }

        public void OnDrag(PointerEventData eventData)
        {
            RectTransform.position += (Vector3)eventData.delta;;
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            IsDragged = true;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            IsDragged = false;
            List<RaycastResult> results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(eventData, results);

            foreach (RaycastResult result in results)
            {
                if (IsValidEndZone(result.gameObject))
                {
                    manager.RemoveEntity(this);
                    Destroy(gameObject);
                    return;
                }
            }
        }
        
        private bool IsValidEndZone(GameObject endZone)
        {
            return (endZone.CompareTag("MiniGameZone1") && EntityData.Good) || 
                   (endZone.CompareTag("MiniGameZone2") && !EntityData.Good);
        }
    }
}