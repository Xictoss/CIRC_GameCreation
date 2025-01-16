using CIRC.Inputs;
using DG.Tweening;
using UnityEngine;

namespace CIRC.MiniGames.Sample
{
    public class Smoke : MonoBehaviour
    {
        public bool isCleaned { get; private set; }
        private int shakeNeed;
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

        private void OnShake(Vector3 vector)
        {
            float screenSize = Mathf.Sqrt(Screen.currentResolution.height * Screen.currentResolution.width) / 4;
            
            rt.DOMove(rt.position + rt.up * screenSize, 0.75f).OnComplete(() =>
            {
                shakeNeed++;
                if (shakeNeed >= 3) isCleaned = true;
            });
        }

        public void DoShake()
        {
            OnShake(Vector3.one);
        }
    }
}