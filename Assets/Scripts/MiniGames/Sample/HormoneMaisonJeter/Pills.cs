using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CIRC.MiniGames.Sample
{
    public class Pills : MonoBehaviour, IDragHandler, IEndDragHandler
    {
        public event Action<Pills> OnEnd;

        public bool isHormonal;
        private RectTransform rt;
        
        private void Awake()
        {
            rt = GetComponent<RectTransform>();
        }

        public void OnDrag(PointerEventData eventData)
        {
            rt.position += (Vector3)eventData.delta;
            
            Debug.Log("Dragggggg");
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if (!isHormonal)
            {
                rt.DOShakePosition(0.2f);
                return;
            }
            
            for (int i = 0; i < eventData.hovered.Count; i++)
            {
                if (eventData.hovered[i].CompareTag("MiniGameZone1"))
                {
                    gameObject.SetActive(false);
                }
            }
        }

        private void OnDisable()
        {
            if (!isHormonal) return;
            
            OnEnd?.Invoke(this);
            Debug.Log("Call Event");
        }
    }
}