using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CIRC.MiniGames.Sample
{
    public class Medicals : MonoBehaviour, IDragHandler, IEndDragHandler
    {
        public bool isGood { get; private set; }
        private RectTransform rt;
        [SerializeField] private Transform spawnAnchor;

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
                if (IsValidEndZone(result.gameObject) && IsValidMedical())
                {
                    transform.position = result.gameObject.transform.position;
                    isGood = true;
                    return;
                }
                transform.DOMove(spawnAnchor.position, 0.5f);
            }
        }

        private bool IsValidEndZone(GameObject endZone)
        {
            return endZone.CompareTag("MiniGameZone1");
        }

        private bool IsValidMedical()
        {
            return gameObject.CompareTag("MiniGameZone2");
        }
    }
}