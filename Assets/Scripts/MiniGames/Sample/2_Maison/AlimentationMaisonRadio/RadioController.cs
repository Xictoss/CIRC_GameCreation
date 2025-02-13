using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace CIRC.MiniGames.Sample
{
    public class RadioController : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private Sprite[] icons;
        [SerializeField] private Image icon;

        private Dictionary<int, Sprite> iconChannels;
        private int currentChannel;
        
        public bool IsArrived { get; private set; }

        private void Awake()
        {
            iconChannels = new Dictionary<int, Sprite>();
            for (int i = 0; i < icons.Length; i++)
            {
                iconChannels.Add(i, icons[i]);
            }

            icon.sprite = icons[currentChannel];
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            ChangeRadio();
        }

        private void ChangeRadio()
        {
            currentChannel = Random.Range(0, icons.Length);
            icon.sprite = icons[currentChannel];

            if (currentChannel == 4)
            {
                IsArrived = true;
            }
            Debug.Log(currentChannel);
        }
    }
}