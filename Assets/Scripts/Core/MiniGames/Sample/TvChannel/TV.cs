using System.Collections.Generic;
using UnityEngine;

namespace CIRC.Core.MiniGames.Sample.TvChannel
{
    public class TV : MonoBehaviour
    {
        public bool IsArrived { get; private set; }

        [SerializeField] private Sprite[] channelsSprite;
        [SerializeField] private int[] channelsNum;
        
        private Dictionary<int, Sprite> channels;

        private void Awake()
        {
            channels = new Dictionary<int, Sprite>();

            for (int index = 0; index < channelsSprite.Length; index++)
            {
                channels[channelsNum[index]] = channelsSprite[index];
            }
        }
    }
}