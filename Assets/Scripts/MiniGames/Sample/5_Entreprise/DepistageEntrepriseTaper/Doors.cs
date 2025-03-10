using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CIRC.MiniGames.Sample
{
    public class Doors : MonoBehaviour, IPointerClickHandler
    {
        public bool isRight { get; private set; }
        [SerializeField] private bool _canSelect = true;

        [SerializeField] private Transform badEntityTransform;
        [SerializeField] private Transform goodEntityTransform;



        public void OnPointerClick(PointerEventData eventData)
        {
            if (!_canSelect) return;

            if (gameObject.CompareTag("MiniGameZone1"))
            {
                _canSelect = false;
                badEntityTransform.DOShakePosition(1, Vector3.right * 100).OnComplete(() => { _canSelect = true; });
            }
            else if (gameObject.CompareTag("MiniGameZone2"))
            {
                goodEntityTransform.DOShakePosition(2, Vector3.up * 10, 30).OnComplete(() =>
                {
                    isRight = true;
                    _canSelect = true;
                });
            }
        }
    }
}