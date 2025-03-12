using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CIRC.MiniGames.Sample
{
    public class FootBall : MonoBehaviour, IDragHandler, IEndDragHandler
    {
        private RectTransform rt;
        public bool isFinished { get; private set; }

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
            Debug.Log(results.Count);

            foreach (RaycastResult result in results)
            {
                if (result.gameObject.CompareTag("MiniGameZone1"))
                {
                    isFinished = true;
                }
            }
        }
    }
}