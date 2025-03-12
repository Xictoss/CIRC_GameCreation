using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CIRC.MiniGames.Sample
{
    public class Hat : MonoBehaviour, IDragHandler, IEndDragHandler
    {

        public bool isArrived { get; private set; }
        
        private RectTransform rt;

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
                    transform.position = result.gameObject.transform.position;
                    isArrived = true;
                    return;
                }
            }
        }

        private bool IsValidEndZone(GameObject endZone)
        {
            return endZone.CompareTag("MiniGameZone1");
        }
    }
}