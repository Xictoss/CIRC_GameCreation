using CIRC.Core.Inputs;
using UnityEngine;
using UnityEngine.UI;

namespace CIRC.Core.MiniGames.Sample.SortAndSplodeMiniGame
{
    public class Entity : MonoBehaviour
    {
        [Header("Entity Data")]
        [field : SerializeField] public EntityData EntityData { get; private set; }
        
        [Header("Move Data")]
        internal RectTransform MoveArea;
        internal bool IsDragged;
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
            if (IsDragged)
            {
                transform.position = InputController.Instance.ScreenTouchPosition;
            }
            else
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
            if (Vector2.Distance(targetPosition, RectTransform.anchoredPosition) <= 10f)
            {
                SetNewTargetPosition();
            }
            
            Vector2 direction = (targetPosition - RectTransform.anchoredPosition).normalized;
            RectTransform.anchoredPosition += direction * (EntityData.Speed * Time.deltaTime);
        }
    }
}