using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CIRC.MiniGames.Sample
{
    public class Bottle : MonoBehaviour, IPointerClickHandler
    {
        public bool isRight { get; private set; }

        
        private bool canClick = true;
        
        public void OnPointerClick(PointerEventData eventData)
        {
            if(!canClick) return;
            
            if (gameObject.CompareTag("MiniGameZone1"))
            {
                canClick = false;
                gameObject.transform.DOShakePosition(1, Vector3.right * 100).OnComplete(()=> canClick = true);
            }
            else if (gameObject.CompareTag("MiniGameZone2"))
            {
                canClick = false;
                gameObject.transform.DOShakeScale(1f).OnComplete(()=>
                {
                    canClick = true;
                    isRight = true;
                });
            }
        }
    }
}