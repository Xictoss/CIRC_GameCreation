using System;
using System.Collections.Generic;
using CIRC.Controllers;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace CIRC.MiniGames.Sample
{
    public class GuyToMotivate : MonoBehaviour, IPointerClickHandler
    {
        public bool isArrived { get; private set; }
        private float GuyToMotivateSpeed => GameMetrics.Global.ALT_GuyToMotivateSpeed;

        [SerializeField] private RectTransform guyToMotivateRt;
        [SerializeField] private RectTransform goalRt;
        

        public void OnPointerClick(PointerEventData eventData)
        {
            Vector3 GoalCenter = goalRt.position;
            
            Bounds bounds2 = guyToMotivateRt.RectTransformToWorldBounds();
            
            guyToMotivateRt.DOMove(new Vector3(guyToMotivateRt.position.x + GuyToMotivateSpeed, guyToMotivateRt.position.y, 0), 1);
            
            if (bounds2.Contains(GoalCenter))
            {
                isArrived = true;
            }
        }
    }
}