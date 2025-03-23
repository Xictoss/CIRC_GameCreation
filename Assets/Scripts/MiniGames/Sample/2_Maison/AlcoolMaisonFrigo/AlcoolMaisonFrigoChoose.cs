using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CIRC.MiniGames.Sample
{
    public class AlcoolMaisonFrigoChoose : MonoBehaviour, IPointerClickHandler
    {
        public bool isFinished { get; private set; }
        [SerializeField] private RectTransform pickUpAnchor;

        public void OnPointerClick(PointerEventData eventData)
        {
            if (gameObject.CompareTag("MiniGameZone1"))
            {
                transform.DOShakePosition(1, Vector3.right * 10, 100);
            }
            else if (gameObject.CompareTag("MiniGameZone2"))
            {
                transform.DOMove(pickUpAnchor.position,2).OnComplete(() => isFinished = true);
            }
        }
    }
}