using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CIRC.MiniGames.Sample
{
    public class CigarettePack : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private Transform GoalTransform;
        public bool isFall { get; private set; }

        
        private bool canClick = true;
        private int shakeRemains = 3;
        
        
        
        public void OnPointerClick(PointerEventData eventData)
        {
            if(!canClick) return;

            canClick = false;
            if (!CheckCheckEnd())
            {
                gameObject.transform.DOShakePosition(1, 20, 50).OnComplete(() =>
                {
                    canClick = true;
                    shakeRemains--;
                });
            }
            else
            {
                gameObject.transform.DOMove(GoalTransform.position, 1.5f).OnComplete(() => {isFall = true; });
            }
        }

        private bool CheckCheckEnd()
        {
            return shakeRemains == 0;
        }
    }
}