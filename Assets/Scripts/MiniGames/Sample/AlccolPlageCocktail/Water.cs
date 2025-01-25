using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CIRC.MiniGames.Sample
{
    public class Water : MonoBehaviour, IDragHandler, IEndDragHandler
    {
        private RectTransform rt;
        public bool IsArrived { get; private set; }

        private void Awake()
        {
            rt = GetComponent<RectTransform>();
        }

        public void OnDrag(PointerEventData eventData)
        {
            rt.position += (Vector3)eventData.delta;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            List<RaycastResult> results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(eventData, results);

            foreach (RaycastResult result in results)
            {
                if (IsValidEndZone(result.gameObject))
                {
                    IsArrived = true;
                    return;
                }
            }
            //Debug.Log($"Is arrived : {IsArrived}");
        }

        private bool IsValidEndZone(GameObject endZone)
        {
            return endZone.CompareTag("MiniGameZone1");
        }
    }
}