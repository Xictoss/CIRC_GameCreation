using DG.Tweening;
using UnityEngine;

namespace CIRC.UIRelated
{
    public class TransitionAnimation : MonoBehaviour
    {
        [SerializeField] private Transform target;
        
        private void Start()
        {
            target.rotation = Quaternion.Euler(0, 0, Random.Range(0, -360));
            target.DORotate(new Vector3(0, 0, 360), 30f, RotateMode.FastBeyond360)
                .SetEase(Ease.Linear)
                .SetLoops(-1, LoopType.Restart);
        }
    }
}