using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace CIRC.MiniGames.Sample
{
    public class TV : MonoBehaviour, IPointerClickHandler
    {
        public bool IsArrived { get; private set; }

        [SerializeField] private Sprite[] channelsSprite;
        [SerializeField] private bool[] isSport;

        [SerializeField] private Image tvScreen;
        
        private Dictionary<Sprite, bool> channels;

        private void Awake()
        {
            channels = new Dictionary<Sprite, bool>();

            for (int i = 0; i < channelsSprite.Length; i++)
            {
                channels.Add(channelsSprite[i], isSport[i]);
            }
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            ChangeChannel();
        }

        private void ChangeChannel()
        {
            int newIndex = Random.Range(0, isSport.Length);
            Sprite newSprite = channelsSprite[newIndex];

            tvScreen.sprite = newSprite;
            if (channels[newSprite])
            {
                IsArrived = true;
            } 
        }
    }
}