using CIRC.Controllers;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

namespace CIRC.MiniGames.Sample
{
    public class Bike : MonoBehaviour, IPointerClickHandler
    {
        public bool IsArrived { get; private set; }
        
        [Header("Mouvement")]
        [SerializeField] private RectTransform bikeTransform;
        [SerializeField] private RectTransform goalTransform;

        private bool canSpam = true;

        private float AVT_BikeSpeed => GameMetrics.Global.AVT_BikeSpeed;
        
        
        public void OnPointerClick(PointerEventData eventData)
        {
            if(!canSpam) return;

            canSpam = false;
            
            Vector3 bikeCenter = bikeTransform.position;
            
            Bounds goalBounds = goalTransform.RectTransformToWorldBounds();
            
            bikeTransform.DOMove(new Vector3(bikeTransform.position.x + AVT_BikeSpeed, bikeTransform.position.y, 0), 1).OnComplete(() =>
                {
                    if (CheckIsArrived(goalBounds, bikeCenter))
                    {
                        IsArrived = true;
                    }
                    else
                    {
                        canSpam = true;
                    }
                    
                });
        }

        private bool CheckIsArrived(Bounds gB, Vector3 bC)
        {
            return gB.Contains(bC);
        }
    }
}