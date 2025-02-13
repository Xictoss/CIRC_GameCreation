using System;
using CIRC.Controllers;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CIRC.MiniGames.Sample
{
    public class GuyRun : MonoBehaviour, IPointerClickHandler
    {
        public bool IsArrived { get; private set; }
        
        [Header("Mouvement")]
        [SerializeField] private RectTransform guyTransform;
        [SerializeField] private RectTransform goalTransform;

        public int GuySpeed => GameMetrics.Global.APN_GuySpeed;
        
        
        public void OnPointerClick(PointerEventData eventData)
        {

            Vector3 GoalCenter = guyTransform.position;
            
            Bounds bounds2 = goalTransform.RectTransformToWorldBounds();
            
            guyTransform.DOMove(new Vector3(guyTransform.position.x + GuySpeed, guyTransform.position.y, 0), 1);
            
            if (bounds2.Contains(GoalCenter))
            {
                Debug.Log("eee");
                IsArrived = true;
            }
            
            Debug.Log(IsArrived);
        }
    }
}