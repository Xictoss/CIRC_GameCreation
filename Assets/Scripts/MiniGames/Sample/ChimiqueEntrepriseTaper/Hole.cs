using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace CIRC.MiniGames.Sample
{
    public class Hole : MonoBehaviour, IPointerClickHandler
    {
        public bool IsArrived { get; private set; }

        private Image image;
        
        private void Awake()
        {
            image = GetComponent<Image>();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (IsArrived) return;

            IsArrived = true;
            image.color = Color.black;
        }
    }
}