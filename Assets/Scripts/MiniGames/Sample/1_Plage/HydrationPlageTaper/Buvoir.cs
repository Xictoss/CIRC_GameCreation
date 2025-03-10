using CIRC.Controllers;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CIRC.MiniGames.Sample
{
    public class Buvoir : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private int RemainsDrinks = 3;
        public bool isFinished { get; private set; }

        private bool canDrink = true;


        public void OnPointerClick(PointerEventData eventData)
        {
            if (!canDrink) return;
            
            canDrink = false;
            gameObject.transform.DOShakePosition(1f, Vector3.down * 100).OnComplete(()=>
            {
                RemainsDrinks--;
                CheckRemainsDrinks();
                canDrink = true;
            });

        }

        private void CheckRemainsDrinks()
        {
            if (RemainsDrinks == 0)
            {
                isFinished = true;
            }
        }
    }
}