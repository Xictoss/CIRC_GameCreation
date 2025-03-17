using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CIRC.MiniGames.Sample
{
    public class Cancer : MonoBehaviour, IPointerClickHandler
    {
        public bool isRight { get; private set; }

        public void OnPointerClick(PointerEventData eventData)
        {
            transform.DOShakePosition(1, Vector3.up * 50).OnComplete(() => isRight = true );
        }
    }
}