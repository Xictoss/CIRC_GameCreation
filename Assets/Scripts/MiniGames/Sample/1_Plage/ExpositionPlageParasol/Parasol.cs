using System;
using CIRC.Inputs;
using DG.Tweening;
using UnityEngine;

namespace CIRC.MiniGames.Sample
{
    public class Parasol : MonoBehaviour
    {
        public bool isFinished { get; private set; }
        private bool canShake = true;

        private int RemainsShakes = 3;
        private RectTransform rt;

        private void Awake()
        {
            rt = GetComponent<RectTransform>();
        }

        private void OnEnable()
        {
            InputController.Instance.OnShakeInput += OnShake;
        }

        private void OnDisable()
        {
            InputController.Instance.OnShakeInput -= OnShake;
        }

        private void OnShake(Vector3 obj)
        {
            if (!canShake) return;
            float screenSize = Mathf.Sqrt(Screen.currentResolution.height * Screen.currentResolution.width) * 0.25f;
            
            canShake = false;
            
            rt.DOMove( rt.position + Vector3.down * screenSize , 2).OnComplete(() =>
            {
                RemainsShakes--;
                CheckShakeRemains();
                canShake = true;
            });
        }

        private void CheckShakeRemains()
        {
            if (RemainsShakes == 0)
            {
                isFinished = true;
            }
        }
    }
}