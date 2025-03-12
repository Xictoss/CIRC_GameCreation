using DG.Tweening;
using UnityEngine;

namespace CIRC.MiniGames.Sample
{
    public class ChoiceManager : MonoBehaviour
    {
        public bool Finished { get; private set; }

        [SerializeField] 
        private RectTransform goodButton;
        [SerializeField] 
        private RectTransform badButton;
        
        public void OnGreatChoice()
        {
            goodButton.DOShakePosition(2, 2f, 100).OnComplete(() => Finished = true);
        }

        public void OnBadChoice()
        {
            badButton.DOShakePosition(2, 2f, 100);
        }

        
    }
}