using System;
using CIRC.Controllers;
using DG.Tweening;
using UnityEngine;
using Image = UnityEngine.UI.Image;

namespace CIRC.MiniGames.Sample
{
    public class Levier : MonoBehaviour
    {
        public bool isFinished { get; private set; }
        [SerializeField] private Image waterImage;

        private float fillAmount;
        private int targetFillAmount = 1;
        private float currentFillAmount = 0f; 
        private float fillSpeed => GameMetrics.Global.HPT_fillSpeed;

        private void Awake()
        {
            waterImage.fillAmount = 0;
        }


        public void PutWaterInGlass()
        {
            DOTween.To(() => waterImage.fillAmount, x => waterImage.fillAmount = x, waterImage.fillAmount + fillSpeed, 0.2f)
                .OnComplete(CheckFullness);

        }

        private void CheckFullness()
        {
            if (waterImage.fillAmount >= 1)
            {
                isFinished = true;
            }
        }
    }
}