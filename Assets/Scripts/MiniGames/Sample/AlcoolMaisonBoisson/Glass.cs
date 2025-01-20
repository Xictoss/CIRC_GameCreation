using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CIRC.MiniGames.Sample
{
    public class Glass : MonoBehaviour, IDragHandler, IEndDragHandler
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
                if (result.gameObject.CompareTag("MiniGameZone1"))
                {
                    isArrived = true;
                    return;
                }
                if (result.gameObject.CompareTag("MiniGameZone2"))
                {
                    rt.DOShakePosition(0.2f, 15f).OnComplete(()=> rt.position = new Vector3(
                        Screen.currentResolution.width/2,
                        Screen.currentResolution.height/2,
                        0));
                    return;
                }
            }
        }
    }
}