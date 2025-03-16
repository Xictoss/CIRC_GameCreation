using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CIRC.MiniGames.Sample
{
    public class VactinationBandage : MonoBehaviour, IDragHandler, IEndDragHandler
    {
        [SerializeField] private RectTransform spawnRt;
        [SerializeField] private RectTransform bandageSpotRt;
        private RectTransform rt;
        private bool canDrag = true;
        public bool IsPlaced { get; private set; }
        
        private void Awake()
        {
            rt = GetComponent<RectTransform>();
        }
        
        public void OnDrag(PointerEventData eventData)
        {
            
            if (IsPlaced || !canDrag) return;

            rt.position += (Vector3)eventData.delta;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            canDrag = false;
            List<RaycastResult> results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(eventData, results);

            foreach (RaycastResult result in results)
            {
                if (IsValidEndZone(result.gameObject))
                {
                    transform.DOMove(bandageSpotRt.position, 0.5f).OnComplete(() => { IsPlaced = true; });
                    return;
                }
            }
            transform.DOMove(spawnRt.position, 0.5f).OnComplete((() => { canDrag = true; }));
            
        }
        
        private bool IsValidEndZone(GameObject endZone)
        {
            return endZone.CompareTag("MiniGameZone1");
        }
    }
}