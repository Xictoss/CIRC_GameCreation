using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CIRC.Core.MiniGames.Sample.AlcoolMaisonFrigo
{
    public class AlcoolMaisonFrigoChoose : MonoBehaviour, IPointerClickHandler
    {
        public bool isFinished { get; private set; }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (gameObject.CompareTag("MiniGameZone1"))
            {
                transform.DOShakePosition(1, Vector3.right * 10, 100);
            }
            else if (gameObject.CompareTag("MiniGameZone2"))
            {
                transform.DOShakePosition(1, Vector3.up * 10, 100).OnComplete(() => isFinished = true);
            }
        }
    }
}