using CIRC.Controllers;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CIRC.MiniGames.Sample
{
    public class CacheBottle : MonoBehaviour, IPointerClickHandler
    {
        public void OnPointerClick(PointerEventData eventData)
        {
            gameObject.transform.DOScale(Vector3.zero, 1).OnComplete(() =>
            {
                gameObject.SetActive(false);
            });
        }
    }
}