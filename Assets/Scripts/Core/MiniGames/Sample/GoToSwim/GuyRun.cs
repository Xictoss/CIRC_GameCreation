using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CIRC.Core.MiniGames.Sample.GoToSwim
{
    public class GuyRun : MonoBehaviour, IPointerClickHandler
    {
        public bool IsArrived { get; private set; }
        
        [Header("Mouvement")]
        [SerializeField] private RectTransform guyTransform;
        [SerializeField] private RectTransform goalTransform;


        public void OnPointerClick(PointerEventData eventData)
        {

            Bounds bounds1 = guyTransform.RectTransformToScreenSpace();
            Bounds bounds2 = goalTransform.RectTransformToScreenSpace();
            guyTransform.DOMove(new Vector3(guyTransform.position.x + 50, guyTransform.position.y, 0), 1);

            if (bounds1.Intersects(bounds2))
            {
                IsArrived = true;
            }
            
            Debug.Log(IsArrived);
        }
    }
}