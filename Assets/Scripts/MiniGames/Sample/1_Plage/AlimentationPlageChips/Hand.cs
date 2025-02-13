using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CIRC.MiniGames.Sample
{
    public class Hand : MonoBehaviour, IDragHandler, IEndDragHandler
    {
        
        public bool isFinished { get; private set; }
        private RectTransform rt;
        
        [Header("Debug")]
        [SerializeField] private int _check;

        [SerializeField] private bool canDrag = true;
        
        [Header("Positions")]
        [SerializeField] Transform PackRt;
        
        private void Awake()
        {
            rt = GetComponent<RectTransform>();
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (!canDrag) return;
            rt.position += (Vector3)eventData.delta;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            canDrag = false;
            
            List<RaycastResult> results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(eventData, results);
            Debug.Log(results.Count);
            foreach (RaycastResult result in results)
            {
                if (IsValidEndZone(result.gameObject))
                {
                    Debug.Log("it's end zone +1");
                    _check++;
                    if (_check == 3)
                    {
                        isFinished = true;
                    }
                    return;
                }
                ReturnTopPack();
            }
        }

        private void ReturnTopPack()
        {
            rt.DOMove(PackRt.position, 1).OnComplete(()=>canDrag=true);
        }
        private bool IsValidEndZone(GameObject appleZone)
        {
            return appleZone.CompareTag("MiniGameZone1");
        }
        
    }
}