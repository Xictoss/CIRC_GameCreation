using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CIRC.MiniGames.Sample
{
    public class Drink : MonoBehaviour, IDragHandler, IEndDragHandler
    {
        [SerializeField] private RectTransform sodaSpotRt;
        [SerializeField] private RectTransform sodaSpawnAnchorRt;
        public bool isRight { get; private set; }
        private bool canDrag = true;
        private RectTransform rt;


        private void Awake()
        {
            rt = GetComponent<RectTransform>();
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (isRight || !canDrag) return;

            rt.position += (Vector3)eventData.delta;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            canDrag = false;
            List<RaycastResult> results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(eventData, results);

            foreach (RaycastResult result in results)
            {
                if (IsValidEndZone(result.gameObject) && IsValidDrink())
                {
                    transform.DOMove(sodaSpotRt.position, 0.5f).OnComplete(() =>
                    {
                        isRight = true;
                    });
                    return;
                }
            }
            transform.DOMove(sodaSpawnAnchorRt.position, 0.5f).OnComplete(() =>
            {
                canDrag = true;
                transform.DOShakePosition(1,20);

            });
        }
        
        private bool IsValidEndZone(GameObject endZone)
        {
            return endZone.CompareTag("MiniGameZone1");
        }

        private bool IsValidDrink()
        {
            return gameObject.CompareTag("MiniGameZone2");
        }
    }
}